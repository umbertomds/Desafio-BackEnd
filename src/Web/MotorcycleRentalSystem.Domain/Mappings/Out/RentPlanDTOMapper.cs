using MotorcycleRentalSystem.DTO.Enums;
using MotorcycleRentalSystem.Domain.Entities;
using MotorcycleRentalSystem.Domain.Enums;
using MotorcycleRentalSystem.DTO.ResponseObjects;

namespace MotorcycleRentalSystem.Domain.Mappings.Out;

public class RentPlanDTOMapper
{
    public RentPlanDTO Map(RentPlan rentPlan) => new()
    {
        PerDayCost = rentPlan.PerDayCost,
        TotalCost = rentPlan.TotalCost,
        PlanPeriod = PlanPeriodResponseMap(rentPlan.PlanPeriod)
    };

    public RentalPlanPeriodDtoEnum PlanPeriodResponseMap(RentalPlanPeriodEnum planPeriod) =>
        Enum.Parse<RentalPlanPeriodDtoEnum>(planPeriod.ToString());
}