namespace MotorcycleRentalSystem.DTO.Responses;
public abstract class ResponseBase
{
    public DateTime Timestamp { get; set; } = DateTime.Now;
}
