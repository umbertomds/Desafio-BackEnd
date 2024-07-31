namespace MotorcycleRentalSystem.DTO.Responses;
public class CreatedResponse(long id) : ResponseBase
{
    public long Id { get; set; } = id;
}
