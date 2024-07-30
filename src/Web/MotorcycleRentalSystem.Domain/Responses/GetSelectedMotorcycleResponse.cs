using MotorcycleRentalSystem.Domain.Entities;

namespace MotorcycleRentalSystem.Domain.Responses;
public class GetSelectedMotorcycleResponse(string path, Motorcycle motorcycle) : ResponseBase
{
    public string Path { get; set; } = path;
    public Motorcycle Motorcycle { get; set; } = motorcycle;
}
