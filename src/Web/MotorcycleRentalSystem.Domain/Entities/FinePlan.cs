using MotorcycleRentalSystem.Domain.Enums;

namespace MotorcycleRentalSystem.Domain.Entities;
public class FinePlan : OrdinaryEntityBase
{
    public PlanFineTypeEnum FineType { get; set; }
    public int Days { get; set; }
    public decimal PerDay { get; set; }
    public decimal Total { get; set; }
}
