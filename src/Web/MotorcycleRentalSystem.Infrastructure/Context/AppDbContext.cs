using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MotorcycleRentalSystem.Domain.Entities;
using MotorcycleRentalSystem.Infrastructure.Configuration;
using MotorcycleRentalSystem.Infrastructure.Seeds;

namespace MotorcycleRentalSystem.Infrastructure.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
        _passwordHasher = new PasswordHasher<User>();
        AdminUsersSeed = new(_passwordHasher);
        ContextConfiguration = new();
    }

    private IPasswordHasher<User> _passwordHasher;
    public DbSet<User> Users { get; set; }
    public DbSet<AdminUser> AdminUsers { get; set; }
    public DbSet<DeliverymanUser> DeliverymanUsers { get; set; }
    public DbSet<Motorcycle> Motorcycles { get; set; }
    public DbSet<RentOrder> RentOrders { get; set; }
    private ContextConfiguration ContextConfiguration { get; set; }
    private AdminUsersSeed AdminUsersSeed { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        // schema
        ContextConfiguration.SchemaConfiguration(modelBuilder);
        // seeds
        AdminUsersSeed.Apply(modelBuilder);
    }
}
