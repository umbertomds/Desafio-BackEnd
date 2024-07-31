using MotorcycleRentalSystem.Domain.Entities;
using MotorcycleRentalSystem.DTO.Responses;

namespace MotorcycleRentalSystem.Domain.Mappings.Out;

public class GetMotorcyclesResponseMapper
{
    private readonly MotorcycleDTOMapper _mapper = new();
    public GetMotorcyclesResponse Map(
        IEnumerable<Motorcycle> result, long remaining, long offset, long maxCapacity, string filter
    ) => new()
    {
        Remaining = remaining, 
        Offset = offset,
        MaxCapacity = maxCapacity,
        Filter = filter,
        Motorcycles = result.Select(_mapper.Map)
    };
}