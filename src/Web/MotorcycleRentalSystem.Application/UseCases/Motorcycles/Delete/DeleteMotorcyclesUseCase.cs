using MotorcycleRentalSystem.Domain.Entities;
using MotorcycleRentalSystem.Domain.Repositories;
using MotorcycleRentalSystem.Exceptions;
namespace MotorcycleRentalSystem.Application.UseCases.Motorcycles.Delete;

public class DeleteMotorcyclesUseCase(IMotorcycleRepository motorcycleRepository) : IDeleteMotorcyclesUseCase
{
    private readonly IMotorcycleRepository _motorcycleRepository = motorcycleRepository;
    public async Task Execute(long id)
    {
        var cycle = await _motorcycleRepository.GetById(id);
        Validate(id, cycle);
        await _motorcycleRepository.Remove(id);
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
