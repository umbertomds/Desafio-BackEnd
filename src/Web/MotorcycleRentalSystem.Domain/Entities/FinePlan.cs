using MotorcycleRentalSystem.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotorcycleRentalSystem.Domain.Entities;

[ComplexType]
public class FinePlan
{
    public PlanFineTypeEnum FineType { get; set; }
    public int Days { get; set; }
    public decimal PerDay { get; set; }
    public decimal Total { get; set; }
}
