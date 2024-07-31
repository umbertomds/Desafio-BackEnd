using MotorcycleRentalSystem.DTO.ResponseObjects;

namespace MotorcycleRentalSystem.DTO.Responses;
public class GetSelectedMotorcycleResponse : ResponseBase
{
    public string? Path { get; set; }
    public MotorcycleDTO? Motorcycle { get; set; }
}
