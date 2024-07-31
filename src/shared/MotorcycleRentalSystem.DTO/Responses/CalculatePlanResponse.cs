using MotorcycleRentalSystem.DTO.ResponseObjects;

namespace MotorcycleRentalSystem.DTO.Responses;
public class CalculatePlanResponse : ResponseBase
{
    public RentPlanDTO? RentPlan { get; set; }
}
