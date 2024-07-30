using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MotorcycleRentalSystem.Domain.Entities;
using MotorcycleRentalSystem.Domain.Services;
using Microsoft.Extensions.Options;
using MotorcycleRentalSystem.Domain.Options;

namespace MotorcycleRentalSystem.Infrastructure.Services;
public class TokenService(IOptions<AppSettings> appSettings) : ITokenService
{
    private readonly AppSettings _appSettings = appSettings.Value;

    private int CLOCK_SKEW => _appSettings.JwtAuthentication?.ClockSkew ?? 0;
    private int EXPIRATION_TIME => _appSettings.JwtAuthentication?.TokenExpiration ?? 60;

    public object GetDecodedJwtToken(string token, string secret)
    { 
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(secret);
        tokenHandler.ValidateToken(token, new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false,
            ClockSkew = TimeSpan.FromMinutes(CLOCK_SKEW)
        }, out SecurityToken validatedToken);

        return (JwtSecurityToken)validatedToken;
    }

    public string GetNewEncodedJwtToken(User user, string secret)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity([ new("id", user.Id.ToString()) ]),
            Expires = DateTime.UtcNow.AddMinutes(EXPIRATION_TIME),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public bool ValidateToken(string token, string secret, bool ignoreExceptions = true)
    {
        JwtSecurityToken? ret = null;
        try
        {
            ret = GetDecodedJwtToken(token, secret) as JwtSecurityToken;
        }
        catch (Exception)
        {
            if (!ignoreExceptions)
                throw;
        }
        return ret is not null;
    }
}
