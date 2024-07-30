using Microsoft.AspNetCore.Mvc;
using MotorcycleRentalSystem.Domain.Services;
using MotorcycleRentalSystem.Domain.Requests;
using MotorcycleRentalSystem.Domain.Responses;
using MotorcycleRentalSystem.Application.UseCases.Authorization.Execute;
using MotorcycleRentalSystem.Exceptions;

namespace MotorcycleRentalSystem.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class AuthenticationController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(AuthenticateResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(UnauthorizedAuthenticationResponse), StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Authenticate([FromServices] IExecuteAuthorizationUseCase useCase, [FromBody] AuthenticateRequest request)
    {
        try
        {
            return Ok(await useCase.Execute(request));
        }
        catch (ApplicationExceptionBase e)
        {
            return Unauthorized(
                new UnauthorizedAuthenticationResponse(e.Message, request.Username!)
            );
        }
    }
}