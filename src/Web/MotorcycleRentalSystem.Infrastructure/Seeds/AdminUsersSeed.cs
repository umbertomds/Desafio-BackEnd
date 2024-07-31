using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MotorcycleRentalSystem.Domain.Entities;

namespace MotorcycleRentalSystem.Infrastructure.Seeds;

public class AdminUsersSeed(IPasswordHasher<User> passwordHasher)
{
    private readonly IPasswordHasher<User> _passwordHasher = passwordHasher;
    public void Apply(ModelBuilder modelBuilder)
    {
        User admin = new()
        {
            Id = 1,
            Name = "Administrator",
            Username = "admin@admin.com.br",
            UserRole = Domain.Enums.UserRoleEnum.AdminRole,
            Password = "admin@paswd24",
            CreateAt = DateTime.MinValue,
            ModifiedAt = DateTime.MinValue,
        };
        admin.Password = _passwordHasher.HashPassword(admin, admin.Password);

        modelBuilder.Entity<AdminUser>().HasData([admin]);
    }

}
