using MotorcycleRentalSystem.Domain.Entities;
using MotorcycleRentalSystem.DTO.Responses;

namespace MotorcycleRentalSystem.Domain.Mappings.Out;

public class CalculateFineResponseMapper
{
    public CalculateFineResponse Map(FinePlan finePlan, string description) => new()
    {
        FinePlan = new FinePlanDTOMapper().Map(finePlan),
        FineDescription = description
    };

}