using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MotorcycleRentalSystem.Domain.Entities;
using MotorcycleRentalSystem.Infrastructure.Configuration;
using MotorcycleRentalSystem.Infrastructure.Seeds;

namespace MotorcycleRentalSystem.Infrastructure.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    { }
    public DbSet<User> Users { get; set; }
    public DbSet<AdminUser> AdminUsers { get; set; }
    public DbSet<DeliverymanUser> DeliverymanUsers { get; set; }
    public DbSet<Motorcycle> Motorcycles { get; set; }
    public DbSet<RentOrder> RentOrders { get; set; }
    private ContextConfiguration ContextConfiguration { get; set; } = new();
    private AdminUsersSeed AdminUsersSeed { get; set; } = new();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        // schema
        ContextConfiguration.SchemaConfiguration(modelBuilder);
        // seeds
        AdminUsersSeed.Apply(modelBuilder);
    }
}
