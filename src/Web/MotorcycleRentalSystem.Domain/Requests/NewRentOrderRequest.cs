using System.ComponentModel.DataAnnotations;
using MotorcycleRentalSystem.Domain.Enums;

namespace MotorcycleRentalSystem.Domain.Requests;
public class NewRentOrderRequest
{
    [Required] 
    public long MotorcycleId { get; set; }
    [Required] 
    public RentalPlanPeriodEnum PlanPeriod { get; set; }
}