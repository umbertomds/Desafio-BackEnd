using MotorcycleRentalSystem.DTO.Requests;
using MotorcycleRentalSystem.DTO.Responses;

namespace MotorcycleRentalSystem.Application.UseCases.Authorization.Execute;
public interface IExecuteAuthorizationUseCase
{
    Task<AuthenticateResponse> Execute(AuthenticateRequest request);
}
