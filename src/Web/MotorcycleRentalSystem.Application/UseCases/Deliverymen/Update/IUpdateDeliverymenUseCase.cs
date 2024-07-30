using MotorcycleRentalSystem.Domain.Requests;

namespace MotorcycleRentalSystem.Application.UseCases.Deliverymen.Update;
public interface IUpdateDeliverymenUseCase
{
    void Execute(UpdateDriverLicenseRequest request, long id);
}
