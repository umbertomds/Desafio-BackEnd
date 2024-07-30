using MotorcycleRentalSystem.Domain.Requests;

namespace MotorcycleRentalSystem.Application.UseCases.Motorcycles.Create;
public interface ICreateMotorcyclesUseCase
{
    long Execute(NewMotorcycleRequest request);
}
