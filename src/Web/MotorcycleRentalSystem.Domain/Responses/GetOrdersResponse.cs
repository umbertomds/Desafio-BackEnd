namespace MotorcycleRentalSystem.Domain.Responses;
public class GetOrdersResponse(IEnumerable<Entities.RentOrder> result, long remaining, long offset, long maxCapacity) : ResponseBase
{
    public IEnumerable<Entities.RentOrder> Orders { get; set; } = result;
    public long Remaining { get; set; } = remaining;
    public long Offset { get; set; } = offset;
    public long MaxCapacity { get; set; } = maxCapacity;
}
