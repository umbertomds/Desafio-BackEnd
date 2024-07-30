using MotorcycleRentalSystem.Domain.Requests;

namespace MotorcycleRentalSystem.Application.UseCases.Deliverymen.Create;
public interface ICreateDeliverymenUseCase
{
    long Execute(NewDeliverymanUserRequest request);
}
