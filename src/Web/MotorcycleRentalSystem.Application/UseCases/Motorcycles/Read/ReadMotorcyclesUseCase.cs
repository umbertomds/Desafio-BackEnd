using Microsoft.Extensions.Options;
using MotorcycleRentalSystem.Domain.Entities;
using MotorcycleRentalSystem.Domain.Enums;
using MotorcycleRentalSystem.Domain.Options;
using MotorcycleRentalSystem.Domain.Responses;
using MotorcycleRentalSystem.Domain.Services;
using MotorcycleRentalSystem.Exceptions;

namespace MotorcycleRentalSystem.Application.UseCases.Motorcycles.Read;

public class ReadMotorcyclesUseCase(IMotorcycleService motorcycleService, IOptions<AppSettings> appSettings) : IReadMotorcyclesUseCase
{
    private readonly IMotorcycleService _motorcycleService = motorcycleService;
    private readonly AppSettings _appSettings = appSettings.Value;

    private int QUANTITY_MAX => _appSettings.WideQueries?.MotorcyclesMaxEntries ?? 100;
    public GetMotorcyclesResponse Execute(UserRoleEnum role, int offset, int quantity, AvailabilityFilterEnum availabilityFilter)
    {
        string filter = "";

        if (offset < 0)
            offset = 0;
        if (quantity <= 0 || quantity > QUANTITY_MAX)
            quantity = QUANTITY_MAX;

        var results = _motorcycleService.GetAll();

        if (role == UserRoleEnum.RegularRole)
            availabilityFilter = AvailabilityFilterEnum.OnlyAvailable;

        if (availabilityFilter == AvailabilityFilterEnum.OnlyAvailable)
        {
            results = results.Where(x => x.IsLastOrderActive);
            filter = "only available ones";
        }
        else if (availabilityFilter == AvailabilityFilterEnum.OnlyUnavailable)
        {
            results = results.Where(x => !x.IsLastOrderActive);
            filter = "only unavailable ones";
        }
        var resultsAfterSkip = _motorcycleService.GetAll().Skip(offset);
        var result = resultsAfterSkip.Take(quantity);
        var remaining = resultsAfterSkip.Count() - quantity;
        if (remaining < 0)
            remaining = 0;
        return new GetMotorcyclesResponse(result, remaining, offset, quantity, filter);
    }

    public GetSelectedMotorcycleResponse Execute(long id) => Execute(id, "");
    public GetSelectedMotorcycleResponse Execute(string licensePlate) => Execute(0, licensePlate);
    private GetSelectedMotorcycleResponse Execute(long id = 0, string licensePlate = "")
    {
        Motorcycle? cycle = null;
        if (id != 0)
            cycle = _motorcycleService.GetById(id);
        else
            cycle = _motorcycleService.GetByLicensePlateNumber(licensePlate);

        if (cycle is null)
            throw new EntityNotFoundException(
                "The requested vehicle was not found.",
                typeof(Motorcycle), id
            );
        return new GetSelectedMotorcycleResponse("", cycle);
    }
}
