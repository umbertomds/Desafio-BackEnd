using MotorcycleRentalSystem.DTO.Requests;

namespace MotorcycleRentalSystem.Application.UseCases.Deliverymen.Create;
public interface ICreateDeliverymenUseCase
{
    Task<long> Execute(NewDeliverymanUserRequest request);
}
