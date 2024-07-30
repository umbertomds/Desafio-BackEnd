using MotorcycleRentalSystem.Domain.Entities;
using MotorcycleRentalSystem.Domain.Services;
using MotorcycleRentalSystem.Exceptions;
namespace MotorcycleRentalSystem.Application.UseCases.Motorcycles.Delete;

public class DeleteMotorcyclesUseCase(IMotorcycleService motorcycleService) : IDeleteMotorcyclesUseCase
{
    private readonly IMotorcycleService _motorcycleService = motorcycleService;
    public void Execute(long id)
    {
        var cycle = _motorcycleService.GetById(id);
        Validate(id, cycle);
        _motorcycleService.Remove(id);
    }

    private void Validate(long id, Motorcycle? cycle)
    {
        if (cycle is null)
            throw new EntityNotFoundException(
                "The requested vehicle was not found.", typeof(Motorcycle), id
            );

        if (cycle.RentOrders is not null && cycle.RentOrders.Count() > 0)
            throw new BusinessLogicValidationFaultException(
                "Cannot proceed with the request: This vehicle has related orders."
            ); 
    }
}
