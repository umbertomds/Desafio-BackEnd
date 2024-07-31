using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MotorcycleRentalSystem.Domain.Entities;

namespace MotorcycleRentalSystem.Infrastructure.Configuration;
public class ContextConfiguration
{
    public void SchemaConfiguration(ModelBuilder modelBuilder)
    {
        // hierarchy
        modelBuilder.Entity<User>().UseTphMappingStrategy();

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
