namespace MotorcycleRentalSystem.DTO.ResponseObjects;

public class RentOrderDTO
{
    public long DeliverymanId { get; set; }
    public MotorcycleDTO? Motorcycle { get; set; }
    public RentPlanDTO? RentPlan { get; set; }
    public FinePlanDTO? FinePlan { get; set; } 
    public DateTime BeginAt { get; set; }
    public DateTime EstimatedEndAt { get; set; }
    public DateTime EndAt { get; set; }
    public decimal TotalCost { get; set; }
}
