using MotorcycleRentalSystem.DTO.Enums;
using MotorcycleRentalSystem.DTO.ResponseObjects;
using MotorcycleRentalSystem.Domain.Entities;
using MotorcycleRentalSystem.Domain.Enums;

namespace MotorcycleRentalSystem.Domain.Mappings.Out;

public class FinePlanDTOMapper
{
    public FinePlanDTO Map(FinePlan finePlan) => new()
    {
        Days = finePlan.Days,
        PerDay = finePlan.PerDay,
        Total = finePlan.Total,
        FineType = FineTypeResponseMap(finePlan.FineType)
    };

    public PlanFineTypeDtoEnum FineTypeResponseMap(PlanFineTypeEnum fineType) =>
    fineType switch
    {
        PlanFineTypeEnum.LatenessFine => PlanFineTypeDtoEnum.LatenessFine,
        PlanFineTypeEnum.FineOverRemainingDays => PlanFineTypeDtoEnum.FineOverRemainingDays,
        _ => PlanFineTypeDtoEnum.None
    };
}