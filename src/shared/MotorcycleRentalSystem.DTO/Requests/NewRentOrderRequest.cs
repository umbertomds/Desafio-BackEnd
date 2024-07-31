using MotorcycleRentalSystem.DTO.Enums;
using System.ComponentModel.DataAnnotations;

namespace MotorcycleRentalSystem.DTO.Requests;
public class NewRentOrderRequest
{
    [Required] 
    public long MotorcycleId { get; set; }
    [Required]
    public RentalPlanPeriodDtoEnum PlanPeriod { get; set; }
}