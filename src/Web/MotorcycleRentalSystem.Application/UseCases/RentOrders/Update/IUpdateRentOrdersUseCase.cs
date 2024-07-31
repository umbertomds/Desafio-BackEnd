using MotorcycleRentalSystem.DTO.Requests;

namespace MotorcycleRentalSystem.Application.UseCases.RentOrders.Update;
public interface IUpdateRentOrdersUseCase
{
    Task Execute(UpdateOrderRequest request, long id, long userId);
}
