using MotorcycleRentalSystem.Domain.Enums;

namespace MotorcycleRentalSystem.Domain.Entities;

public class DriverLicense
{
    public string? Number { get; set; }
    public LicenseTypeEnum Type { get; set; }
    public string? Picture { get; set; }
}
