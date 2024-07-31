using Microsoft.Extensions.Options;
using MotorcycleRentalSystem.Domain.Entities;
using MotorcycleRentalSystem.Domain.Enums;
using MotorcycleRentalSystem.Domain.Mappings.Out;
using MotorcycleRentalSystem.Domain.Options;
using MotorcycleRentalSystem.DTO.Responses;
using MotorcycleRentalSystem.Exceptions;
using MotorcycleRentalSystem.Domain.Repositories;

namespace MotorcycleRentalSystem.Application.UseCases.Motorcycles.Read;

public class ReadMotorcyclesUseCase(IMotorcycleRepository motorcycleRepository, IOptions<AppSettings> appSettings) : IReadMotorcyclesUseCase
{
    private readonly IMotorcycleRepository _motorcycleRepository = motorcycleRepository;
    private readonly AppSettings _appSettings = appSettings.Value;

    private int QUANTITY_MAX => _appSettings.WideQueries?.MotorcyclesMaxEntries ?? 100;
    public async Task<GetMotorcyclesResponse> Execute(UserRoleEnum role, int offset, int quantity, AvailabilityFilterEnum availabilityFilter)
    {
        string filter = "";

        if (offset < 0)
            offset = 0;
        if (quantity <= 0 || quantity > QUANTITY_MAX)
            quantity = QUANTITY_MAX;

        var results = await _motorcycleRepository.GetAll();

        if (role == UserRoleEnum.RegularRole)
            availabilityFilter = AvailabilityFilterEnum.OnlyAvailable;

        if (availabilityFilter == AvailabilityFilterEnum.OnlyAvailable)
        {
            results = results.Where(x => x.IsLastOrderActive).ToList();
            filter = "only available ones";
        }
        else if (availabilityFilter == AvailabilityFilterEnum.OnlyUnavailable)
        {
            results = results.Where(x => !x.IsLastOrderActive).ToList();
            filter = "only unavailable ones";
        }
        var resultsAfterSkip = (await _motorcycleRepository.GetAll()).Skip(offset);
        var result = resultsAfterSkip.Take(quantity);
        var remaining = resultsAfterSkip.Count() - quantity;
        if (remaining < 0)
            remaining = 0;
        return new GetMotorcyclesResponseMapper().Map(result, remaining, offset, quantity, filter);
    }

    public async Task<GetSelectedMotorcycleResponse> Execute(long id) => await Execute(id, "");
    public async Task<GetSelectedMotorcycleResponse> Execute(string licensePlate) => await Execute(0, licensePlate);
    private async Task<GetSelectedMotorcycleResponse> Execute(long id = 0, string licensePlate = "")
    {
        Motorcycle? cycle = null;
        if (id != 0)
            cycle = await _motorcycleRepository.GetById(id);
        else
            cycle = await _motorcycleRepository.GetByLicensePlateNumber(licensePlate);

        if (cycle is null)
            throw new EntityNotFoundException(
                "The requested vehicle was not found.",
                typeof(Motorcycle), id
            );
        return new GetSelectedMotorcycleResponseMapper().Map("", cycle);
    }
}
