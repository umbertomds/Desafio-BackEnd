namespace MotorcycleRentalSystem.Domain.Responses;
public class CreatedResponse(long id) : ResponseBase
{
    public long Id { get; set; } = id;
}
