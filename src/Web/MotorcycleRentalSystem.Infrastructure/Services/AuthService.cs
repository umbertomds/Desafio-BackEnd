using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MotorcycleRentalSystem.Domain.Contracts;
using MotorcycleRentalSystem.Domain.Entities;
using MotorcycleRentalSystem.Domain.Mappings.Out;
using MotorcycleRentalSystem.Domain.Options;
using MotorcycleRentalSystem.Domain.Services;
using MotorcycleRentalSystem.DTO.Requests;
using MotorcycleRentalSystem.DTO.Responses;
using MotorcycleRentalSystem.Infrastructure.Context;
using System.Security.Cryptography;

namespace MotorcycleRentalSystem.Infrastructure.Services;
public class AuthService(
    ITokenService tokenService, IPasswordHasher<User> passwordHasher, AppDbContext appDbContext, 
    IUnitOfWork unitOfWork, IOptions<AppSettings> appSettings) : IAuthService
{
    private readonly AppDbContext _dbContext = appDbContext;
    private readonly AppSettings _appSettings = appSettings.Value;
    private readonly ITokenService _tokenService = tokenService;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IPasswordHasher<User> _passwordHasher = passwordHasher;

    public async Task<AuthenticateResponse?> Authenticate(AuthenticateRequest model)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Username == model.Username);
        if (user == null)
            return null;
        
        var comparison = _passwordHasher.VerifyHashedPassword(user, user.Password!, model.Password!);
        if (comparison == PasswordVerificationResult.Failed)
            return null;

        var secret = _appSettings.JwtAuthentication!.Secret ?? "";
        var token = _tokenService.GetNewEncodedJwtToken(user, secret);
        return new AuthenticateResponseMapper().Map(user, token);
    }
}
