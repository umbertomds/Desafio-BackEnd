using MotorcycleRentalSystem.Domain.Requests;
using MotorcycleRentalSystem.Domain.Responses;
using MotorcycleRentalSystem.Domain.Services;
using MotorcycleRentalSystem.Exceptions;

namespace MotorcycleRentalSystem.Application.UseCases.Authorization.Execute;

public class ExecuteAuthorizationUseCase(IUserService userService) : IExecuteAuthorizationUseCase
{
    private readonly IUserService _userService = userService;
    public async Task<AuthenticateResponse> Execute(AuthenticateRequest request)
    {
        return await Task.Run(() => {
            var response = _userService.Authenticate(request);
            return response is null ? throw new AuthenticationFailedException() : response;
        });
    }
}
