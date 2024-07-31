using MotorcycleRentalSystem.DTO.ResponseObjects;
using MotorcycleRentalSystem.Domain.Entities;

namespace MotorcycleRentalSystem.Domain.Mappings.Out;

public class MotorcycleDTOMapper
{
    public MotorcycleDTO Map(Motorcycle motorcycle) => new()
    {
        LicensePlate = motorcycle.LicensePlate,
        ManufacturedAt = motorcycle.ManufacturedAt,
        Model = motorcycle.Model
    };
}