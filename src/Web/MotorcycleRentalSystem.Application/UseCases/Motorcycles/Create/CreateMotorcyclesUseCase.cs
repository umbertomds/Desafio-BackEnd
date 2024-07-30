using MotorcycleRentalSystem.Domain.Entities;
using MotorcycleRentalSystem.Domain.Requests;
using MotorcycleRentalSystem.Domain.Services;
using MotorcycleRentalSystem.Exceptions;

namespace MotorcycleRentalSystem.Application.UseCases.Motorcycles.Create;

public class CreateMotorcyclesUseCase(IMotorcycleService motorcycleService) : ICreateMotorcyclesUseCase
{
    private readonly IMotorcycleService _motorcycleService = motorcycleService;
    public long Execute(NewMotorcycleRequest request)
    {
        if (_motorcycleService.GetByLicensePlateNumber(request.LicensePlate!) is not null)
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
        _motorcycleService.AddNewMotorcycle(cycle);
        return cycle.Id;
    }
}
