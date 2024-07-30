using MotorcycleRentalSystem.Domain.Entities;
using MotorcycleRentalSystem.Domain.Enums;

namespace MotorcycleRentalSystem.Domain.Responses;
public class AuthenticateResponse(User user, string token) : ResponseBase
{
    public long Id { get; set; } = user.Id;
    public UserRoleEnum UserRole { get; set; } = user.UserRole;
    public string Username { get; set; } = user.Username!;
    public string Name { get; set; } = user.Name ?? "";
    public string Token { get; set; } = token;
}