using MotorcycleRentalSystem.Domain.Entities;
using MotorcycleRentalSystem.DTO.ResponseObjects;

namespace MotorcycleRentalSystem.Domain.Mappings.Out;

public class RentOrderDTOMapper
{
    public RentOrderDTO Map(RentOrder order) => new()
    {
        BeginAt = order.BeginAt,
        EndAt = order.EndAt,
        EstimatedEndAt = order.EstimatedEndAt,
        FinePlan = new FinePlanDTOMapper().Map(order.FinePlan),
        RentPlan = new RentPlanDTOMapper().Map(order.RentPlan),
        TotalCost = order.TotalCost,
        DeliverymanId = order.Deliveryman?.Id ?? 0,
        Motorcycle = null
    };
}