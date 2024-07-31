using MotorcycleRentalSystem.DTO.Requests;

namespace MotorcycleRentalSystem.Application.UseCases.Deliverymen.Update;
public interface IUpdateDeliverymenUseCase
{
    Task Execute(UpdateDriverLicenseRequest request, long id);
}
