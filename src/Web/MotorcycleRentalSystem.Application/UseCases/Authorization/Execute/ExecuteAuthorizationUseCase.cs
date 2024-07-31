using MotorcycleRentalSystem.DTO.Requests;
using MotorcycleRentalSystem.DTO.Responses;
using MotorcycleRentalSystem.Exceptions;
using MotorcycleRentalSystem.Domain.Services;
using Microsoft.AspNetCore.Identity;
using MotorcycleRentalSystem.Domain.Entities;

namespace MotorcycleRentalSystem.Application.UseCases.Authorization.Execute;

public class ExecuteAuthorizationUseCase(IAuthService authService) : IExecuteAuthorizationUseCase
{
    private readonly IAuthService _authService = authService;
    public async Task<AuthenticateResponse> Execute(AuthenticateRequest request)
    {

        var ws = new PasswordHasher<User>();
        
        var response = await _authService.Authenticate(request);
        return response is null ? throw new AuthenticationFailedException() : response;
    }
}
