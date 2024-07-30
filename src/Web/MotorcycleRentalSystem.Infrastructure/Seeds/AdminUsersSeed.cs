using Microsoft.EntityFrameworkCore;
using MotorcycleRentalSystem.Domain.Entities;

namespace MotorcycleRentalSystem.Infrastructure.Seeds;

public class AdminUsersSeed
{
    public void Apply(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdminUser>().HasData(
        [
            new ()
            {
                Id = 1,
                Name = "Administrator",
                Username = "admin@admin.com.br",
                UserRole = Domain.Enums.UserRoleEnum.AdminRole,
                Password = "admin@paswd24",
                CreateAt = DateTime.MinValue,
                ModifiedAt = DateTime.MinValue,
            }
        ]);
    }

}
