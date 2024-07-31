using MotorcycleRentalSystem.Domain.Entities;
using MotorcycleRentalSystem.DTO.Responses;

namespace MotorcycleRentalSystem.Domain.Mappings.Out;

public class GetSelectedMotorcycleResponseMapper
{
    public GetSelectedMotorcycleResponse Map(string path, Motorcycle motorcycle) => new()
    {
        Path = path,
        Motorcycle = new MotorcycleDTOMapper().Map(motorcycle)
    };
}