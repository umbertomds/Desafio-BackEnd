using MotorcycleRentalSystem.Domain.Requests;
using MotorcycleRentalSystem.Domain.Responses;

namespace MotorcycleRentalSystem.Application.UseCases.Authorization.Execute;
public interface IExecuteAuthorizationUseCase
{
    Task<AuthenticateResponse>  Execute(AuthenticateRequest request);
}
