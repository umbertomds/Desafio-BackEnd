using MotorcycleRentalSystem.DTO.Enums;

namespace MotorcycleRentalSystem.DTO.ResponseObjects;
public class RentPlanDTO
{
    public RentalPlanPeriodDtoEnum PlanPeriod { get; set; }
    public decimal PerDayCost { get; set; }
    public decimal TotalCost { get; set; }
}
