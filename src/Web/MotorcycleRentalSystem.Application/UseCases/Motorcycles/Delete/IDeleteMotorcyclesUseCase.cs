namespace MotorcycleRentalSystem.Application.UseCases.Motorcycles.Delete;
public interface IDeleteMotorcyclesUseCase
{
    Task Execute(long id);
}
