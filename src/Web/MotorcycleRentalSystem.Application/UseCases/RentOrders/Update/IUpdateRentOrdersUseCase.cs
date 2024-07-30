using MotorcycleRentalSystem.Domain.Requests;

namespace MotorcycleRentalSystem.Application.UseCases.RentOrders.Update;
public interface IUpdateRentOrdersUseCase
{
    void Execute(UpdateOrderRequest request, long id, long userId);
}
