using Microsoft.Extensions.Options;
using MotorcycleRentalSystem.Domain.Options;
using MotorcycleRentalSystem.Domain.Repositories;
using MotorcycleRentalSystem.Domain.Services;
using System.IdentityModel.Tokens.Jwt;

namespace MotorcycleRentalSystem.Api.Middlewares;

public class JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
{
    private readonly RequestDelegate _next = next;
    private readonly AppSettings _appSettings = appSettings.Value;
    private ITokenService? _tokenService = null;

    public async Task Invoke(HttpContext context, IUserRepository userRepository)
    {
        _tokenService = context.RequestServices.GetService<ITokenService>();
        
        var artifacts = context.Request.Headers["Authorization"];
        if (artifacts.Count() != 1)
        {
            await _next(context);
            return;
        }
        
        var bearerToken = artifacts[0];
        if (!bearerToken!.Contains(' '))
        {
            await _next(context);
            return;
        }

        var splittedBearer = bearerToken.Split(' ');
        if ( splittedBearer.Length != 2 || splittedBearer[0] != "Bearer")
        {
            await _next(context);
            return;
        }

        var token = splittedBearer[1];
        if (token is not null)
            await attachUserToContext(context, userRepository, token);

        await _next(context);
    }

    private async Task attachUserToContext(HttpContext context, IUserRepository userRepository, string token)
    {
        try
        {
            if (_tokenService is null)
                return;

            var secret = _appSettings.JwtAuthentication?.Secret ?? "";
            var jwtToken = _tokenService.GetDecodedJwtToken(token, secret) as JwtSecurityToken;
            var userId = long.Parse(jwtToken!.Claims.First(x => x.Type == "id").Value);

            context.Items["User"] = await userRepository.GetById(userId);
        }
        catch
        {
            // does nothing if jwt validation doesn't go
            // in this case, the user object won't be attached then auth-needing actions won't go anyway 
        }
    }
}