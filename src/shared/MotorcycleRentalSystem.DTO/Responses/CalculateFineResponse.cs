using MotorcycleRentalSystem.DTO.ResponseObjects;

namespace MotorcycleRentalSystem.DTO.Responses;
public class CalculateFineResponse : ResponseBase
{
    public FinePlanDTO? FinePlan { get; set; }
    public string? FineDescription { get; set; }
}
