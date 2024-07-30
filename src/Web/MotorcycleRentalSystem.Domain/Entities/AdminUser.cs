using MotorcycleRentalSystem.Domain.Enums;

namespace MotorcycleRentalSystem.Domain.Entities;
public class AdminUser : User
{
    public override UserRoleEnum UserRole { get => UserRoleEnum.AdminRole; set => _ = value; }
}
