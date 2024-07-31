using MotorcycleRentalSystem.DTO.Requests;

namespace MotorcycleRentalSystem.Application.UseCases.Motorcycles.Update;
public interface IUpdateMotorcyclesUseCase
{
    Task Execute(UpdateLicensePlateRequest request, long id);
}
