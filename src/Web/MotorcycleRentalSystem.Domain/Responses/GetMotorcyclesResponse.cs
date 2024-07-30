namespace MotorcycleRentalSystem.Domain.Responses;
public class GetMotorcyclesResponse(
    IEnumerable<Entities.Motorcycle> result, 
    long remaining, long offset, long maxCapacity, string filter) : ResponseBase
{
    public IEnumerable<Entities.Motorcycle> Motorcycles { get; set; } = result;
    public long Remaining { get; set; } = remaining;
    public long Offset { get; set; } = offset;
    public long MaxCapacity { get; set; } = maxCapacity;
    public string Filter { get; set; } = filter;
}
