using MotorcycleRentalSystem.Domain.Entities;
using MotorcycleRentalSystem.DTO.Responses;

namespace MotorcycleRentalSystem.Domain.Mappings.Out;

public class CalculatePlanResponseMapper
{
    public CalculatePlanResponse Map(RentPlan rentPlan) => new()
    {
        RentPlan = new RentPlanDTOMapper().Map(rentPlan)
    };
}