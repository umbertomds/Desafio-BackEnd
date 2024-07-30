using MotorcycleRentalSystem.Domain.Requests;

namespace MotorcycleRentalSystem.Application.UseCases.Motorcycles.Update;
public interface IUpdateMotorcyclesUseCase
{
    void Execute(UpdateLicensePlateRequest request, long id);
}
