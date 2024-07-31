using MotorcycleRentalSystem.Domain.Enums;
using MotorcycleRentalSystem.DTO.Responses;

namespace MotorcycleRentalSystem.Application.UseCases.Motorcycles.Read;
public interface IReadMotorcyclesUseCase
{
    Task<GetMotorcyclesResponse> Execute(UserRoleEnum role, int offset, int quantity, 
        AvailabilityFilterEnum availabilityFilter);
    Task<GetSelectedMotorcycleResponse> Execute(long id);
    Task<GetSelectedMotorcycleResponse> Execute(string licensePlate);
}
