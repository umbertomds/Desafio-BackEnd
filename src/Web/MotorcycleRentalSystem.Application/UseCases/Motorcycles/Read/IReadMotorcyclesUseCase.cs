using MotorcycleRentalSystem.Domain.Enums;
using MotorcycleRentalSystem.Domain.Responses;

namespace MotorcycleRentalSystem.Application.UseCases.Motorcycles.Read;
public interface IReadMotorcyclesUseCase
{
    GetMotorcyclesResponse Execute(UserRoleEnum role, int offset, int quantity, 
        AvailabilityFilterEnum availabilityFilter);
    GetSelectedMotorcycleResponse Execute(long id);
    GetSelectedMotorcycleResponse Execute(string licensePlate);
}
