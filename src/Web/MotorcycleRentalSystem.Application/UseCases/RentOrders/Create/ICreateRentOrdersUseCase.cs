using MotorcycleRentalSystem.DTO.Requests;
using MotorcycleRentalSystem.DTO.Responses;

namespace MotorcycleRentalSystem.Application.UseCases.RentOrders.Create;
public interface ICreateRentOrdersUseCase
{
    Task<CreatedResponse> Execute(long id, NewRentOrderRequest request);
}
