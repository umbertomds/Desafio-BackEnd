using MotorcycleRentalSystem.DTO.Requests;

namespace MotorcycleRentalSystem.Application.UseCases.Motorcycles.Create;
public interface ICreateMotorcyclesUseCase
{
    Task<long> Execute(NewMotorcycleRequest request);
}
