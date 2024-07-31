using MotorcycleRentalSystem.DTO.Requests;
using MotorcycleRentalSystem.Domain.Entities;
using MotorcycleRentalSystem.Domain.Services;
using MotorcycleRentalSystem.Exceptions;
using MotorcycleRentalSystem.Domain.Repositories;

namespace MotorcycleRentalSystem.Application.UseCases.Motorcycles.Create;

public class CreateMotorcyclesUseCase(IMotorcycleRepository motorcycleRepository) : ICreateMotorcyclesUseCase
{
    private readonly IMotorcycleRepository _motorcycleRepository = motorcycleRepository;
    public async Task<long> Execute(NewMotorcycleRequest request)
    {
        if (await _motorcycleRepository.GetByLicensePlateNumber(request.LicensePlate!) is not null)
            throw new FieldValidationFaultException(
                "The requested license plate is already in use. Pick another one.",
                "LicensePlate",
                request.LicensePlate!
            );
        
        Motorcycle cycle = new()
        {
            ManufacturedAt = uint.Parse(request.ManufacturingYear ?? "0"),
            Model = request.Model,
            LicensePlate = request.LicensePlate
        };
        await _motorcycleRepository.Add(cycle);
        return cycle.Id;
    }
}
