using MotorcycleRentalSystem.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotorcycleRentalSystem.Domain.Entities;
public class AdminUser : User
{
    [NotMapped]
    public override UserRoleEnum UserRole { get => UserRoleEnum.AdminRole; set => _ = value; }
}
