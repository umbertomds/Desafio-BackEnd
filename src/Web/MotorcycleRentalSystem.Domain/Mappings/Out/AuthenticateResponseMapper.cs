using MotorcycleRentalSystem.DTO.Enums;
using MotorcycleRentalSystem.Domain.Entities;
using MotorcycleRentalSystem.Domain.Enums;
using MotorcycleRentalSystem.DTO.Responses;

namespace MotorcycleRentalSystem.Domain.Mappings.Out;

public class AuthenticateResponseMapper
{
    public AuthenticateResponse Map(User user, string token) => new()
    {
        Id = user.Id,
        Username = user.Username!,
        Name = user.Name ?? "",
        Token = token,
        UserRole = 
            user.UserRole == UserRoleEnum.AdminRole ? 
            UserRoleDtoEnum.AdminRole : UserRoleDtoEnum.RegularRole
    };
}