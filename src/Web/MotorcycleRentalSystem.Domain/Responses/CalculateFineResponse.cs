using MotorcycleRentalSystem.Domain.Entities;

namespace MotorcycleRentalSystem.Domain.Responses;
public class CalculateFineResponse : ResponseBase
{
    public FinePlan? FinePlan { get; set; }
    public string? FineDescription { get; set; }
}
