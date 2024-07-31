using MotorcycleRentalSystem.Domain.Entities;
using MotorcycleRentalSystem.DTO.Responses;

namespace MotorcycleRentalSystem.Domain.Mappings.Out;

public class GetSelectedOrderResponseMapper
{
    public GetSelectedOrderResponse Map(string path, RentOrder rentOrder) => new()
    {
        Path = path,
        RentOrder = new RentOrderDTOMapper().Map(rentOrder)
    };
}