using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MotorcycleRentalSystem.Domain.Entities;

namespace MotorcycleRentalSystem.Infrastructure.Configuration;
public class ContextConfiguration
{
    public void SchemaConfiguration(ModelBuilder modelBuilder)
    {
        // tables
        modelBuilder.Entity<UserEntityBase>().ToTable("Users");
        // relations
        modelBuilder.Entity<DeliverymanUser>().HasOne("DriverLicense");
        modelBuilder.Entity<RentOrder>().HasOne("RentPlan");
        modelBuilder.Entity<RentOrder>().HasOne("FinePlan");
        // hierarchy
        modelBuilder.Entity<UserEntityBase>().UseTphMappingStrategy();

        // datetime fix
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            foreach (var property in entityType.GetProperties())
                if (property.ClrType == typeof(DateTime))
                {
                    property.SetDefaultValue(DateTime.MinValue);
                    property.SetValueConverter(
                        new ValueConverter<DateTime, DateTime>(
                            v => v,
                            v => DateTime.SpecifyKind(v, DateTimeKind.Utc)
                        )
                    );
                }
                    
    }
}
