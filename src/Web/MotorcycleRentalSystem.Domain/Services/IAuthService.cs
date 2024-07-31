using MotorcycleRentalSystem.DTO.Requests;
using MotorcycleRentalSystem.DTO.Responses;

namespace MotorcycleRentalSystem.Domain.Services;

public interface IAuthService
{
    Task<AuthenticateResponse?> Authenticate(AuthenticateRequest model);
}
