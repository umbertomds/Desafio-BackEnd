using MotorcycleRentalSystem.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotorcycleRentalSystem.Domain.Entities;

[ComplexType]
public class DriverLicense
{
    public string? Number { get; set; }
    public LicenseTypeEnum Type { get; set; }
    public string? Picture { get; set; }
}
