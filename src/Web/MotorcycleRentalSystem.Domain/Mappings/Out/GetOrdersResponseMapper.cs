using MotorcycleRentalSystem.Domain.Entities;
using MotorcycleRentalSystem.DTO.Responses;

namespace MotorcycleRentalSystem.Domain.Mappings.Out;

public class GetOrdersResponseMapper
{
    private readonly RentOrderDTOMapper _mapper = new();
    public GetOrdersResponse Map(
        IEnumerable<RentOrder> result, long remaining, long offset, long maxCapacity
    ) => new()
    {
        Remaining = remaining, 
        Offset = offset,
        MaxCapacity = maxCapacity,
        Orders = result.Select(_mapper.Map)
    };
}