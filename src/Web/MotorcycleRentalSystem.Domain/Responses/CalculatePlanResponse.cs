using MotorcycleRentalSystem.Domain.Entities;

namespace MotorcycleRentalSystem.Domain.Responses;
public class CalculatePlanResponse : ResponseBase
{
    public RentPlan? RentPlan { get; set; }
}
