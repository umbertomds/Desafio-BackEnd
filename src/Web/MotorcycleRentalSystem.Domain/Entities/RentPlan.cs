using MotorcycleRentalSystem.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotorcycleRentalSystem.Domain.Entities;

[ComplexType]
public class RentPlan
{
    public RentalPlanPeriodEnum PlanPeriod { get; set; }
    public decimal PerDayCost { get; set; }
    public decimal TotalCost { get; set; }
}
