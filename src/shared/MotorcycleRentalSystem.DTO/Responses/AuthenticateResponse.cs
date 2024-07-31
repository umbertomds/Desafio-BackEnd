using MotorcycleRentalSystem.DTO.Enums;

namespace MotorcycleRentalSystem.DTO.Responses;
public class AuthenticateResponse : ResponseBase
{
    public long Id { get; set; }
    public UserRoleDtoEnum UserRole { get; set; }
    public string? Username { get; set; }
    public string? Name { get; set; }
    public string? Token { get; set; } 
}