using MotorcycleRentalSystem.Domain.Enums;
using MotorcycleRentalSystem.Domain.Responses;

namespace MotorcycleRentalSystem.Application.UseCases.RentOrders.Read;
public interface IReadRentOrdersUseCase
{
    GetOrdersResponse Execute(UserRoleEnum role, long userId, int offset, int quantity);
    GetSelectedOrderResponse Execute(long id);
}
