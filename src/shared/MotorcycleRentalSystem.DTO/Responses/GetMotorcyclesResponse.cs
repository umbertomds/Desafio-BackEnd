using MotorcycleRentalSystem.DTO.ResponseObjects;

namespace MotorcycleRentalSystem.DTO.Responses;
public class GetMotorcyclesResponse : ResponseBase
{
    public IEnumerable<MotorcycleDTO>? Motorcycles { get; set; }
    public long Remaining { get; set; }
    public long Offset { get; set; } 
    public long MaxCapacity { get; set; } 
    public string? Filter { get; set; } 
}
