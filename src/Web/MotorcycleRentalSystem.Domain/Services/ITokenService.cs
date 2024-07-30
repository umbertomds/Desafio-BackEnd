using MotorcycleRentalSystem.Domain.Entities;

namespace MotorcycleRentalSystem.Domain.Services;
public interface ITokenService
{
    public string GetNewEncodedJwtToken(User user, string secret);

    public object? GetDecodedJwtToken(string token, string secret);

    public bool ValidateToken(string token, string secret, bool ignoreExceptions = true);
}
