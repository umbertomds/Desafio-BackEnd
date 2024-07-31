using MotorcycleRentalSystem.DTO.ResponseObjects;

namespace MotorcycleRentalSystem.DTO.Responses;
public class GetOrdersResponse : ResponseBase
{
    public IEnumerable<RentOrderDTO>? Orders { get; set; } 
    public long Remaining { get; set; } 
    public long Offset { get; set; } 
    public long MaxCapacity { get; set; } 
}
