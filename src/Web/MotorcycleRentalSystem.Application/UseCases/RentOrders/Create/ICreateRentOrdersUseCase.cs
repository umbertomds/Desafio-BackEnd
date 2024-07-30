using MotorcycleRentalSystem.Domain.Requests;
using MotorcycleRentalSystem.Domain.Responses;

namespace MotorcycleRentalSystem.Application.UseCases.RentOrders.Create;
public interface ICreateRentOrdersUseCase
{
    CreatedResponse Execute(long id, NewRentOrderRequest request);
}
