using MotorcycleRentalSystem.Domain.Enums;

namespace MotorcycleRentalSystem.Domain.Entities;
public class RentOrder : EntityBase
{
    public DeliverymanUser? Deliveryman { get; set; }
    public Motorcycle? Motorcycle { get; set; }
    public RentPlan RentPlan { get; set; } = new();
    public FinePlan FinePlan { get; set; } = new();
    public DateTime BeginAt { get; set; }
    public DateTime EstimatedEndAt { get; set; }
    public DateTime EndAt { get; set; }
    public decimal TotalCost { get; set; }

    public RentOrderStateEnum State =>
        EndAt > DateTime.MinValue ?
        RentOrderStateEnum.Finished :
        (DateTime.Today <= EndAt ? RentOrderStateEnum.Active : RentOrderStateEnum.Late);
}
