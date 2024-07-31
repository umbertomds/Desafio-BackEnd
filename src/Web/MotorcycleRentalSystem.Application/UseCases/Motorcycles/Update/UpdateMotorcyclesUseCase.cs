using MotorcycleRentalSystem.DTO.Requests;
using MotorcycleRentalSystem.Domain.Entities;
using MotorcycleRentalSystem.Domain.Services;
using MotorcycleRentalSystem.Exceptions;
using MotorcycleRentalSystem.Domain.Repositories;

namespace MotorcycleRentalSystem.Application.UseCases.Motorcycles.Update;

public class UpdateMotorcyclesUseCase(IMotorcycleRepository motorcycleRepository) : IUpdateMotorcyclesUseCase
{
    private readonly IMotorcycleRepository _motorcycleRepository = motorcycleRepository;
    public async Task Execute(UpdateLicensePlateRequest request, long id)
    {
        var cycle = await _motorcycleRepository.GetById(id);
        Validate(id, cycle, request);
        cycle!.LicensePlate = request.NewLicensePlate;
    }

    private void Validate(long id, Motorcycle? cycle, UpdateLicensePlateRequest request)
    {
        if (cycle is null)
            throw new EntityNotFoundException(
                "The requested vehicle was not found.", 
                typeof(Motorcycle), id
            );

        if (cycle.LicensePlate == request.NewLicensePlate)
            throw new FieldValidationFaultException(
                "You cannot update the license plate number using the same registered number.",
                "NewLicensePlate", request.NewLicensePlate!
            );

        if (_motorcycleRepository.GetByLicensePlateNumber(request.NewLicensePlate!) is not null)
            throw new FieldValidationFaultException(
               "The informed license plate number is alredy in use by another vehicle.",
               "NewLicensePlate", request.NewLicensePlate!
            ); 
    }
}
