using MotorcycleRentalSystem.Domain.Enums;
using MotorcycleRentalSystem.DTO.Responses;

namespace MotorcycleRentalSystem.Application.UseCases.RentOrders.Read;
public interface IReadRentOrdersUseCase
{
    Task<GetOrdersResponse> Execute(UserRoleEnum role, long userId, int offset, int quantity);
    Task<GetSelectedOrderResponse> Execute(long id);
}
