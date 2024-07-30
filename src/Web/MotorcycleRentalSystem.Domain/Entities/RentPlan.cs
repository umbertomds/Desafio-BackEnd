using MotorcycleRentalSystem.Domain.Enums;

namespace MotorcycleRentalSystem.Domain.Entities;
public class RentPlan
{
    public RentalPlanPeriodEnum PlanPeriod { get; set; }
    public decimal PerDayCost { get; set; }
    public decimal TotalCost { get; set; }
}
