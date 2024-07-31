using MotorcycleRentalSystem.DTO.Enums;
using MotorcycleRentalSystem.Domain.Enums;

namespace MotorcycleRentalSystem.Domain.Mappings.In;

public class ToRentalPlanPeriodEnum
{
    public RentalPlanPeriodEnum Convert(int rentalPlanPeriod)
    {
        if (Enum.TryParse(rentalPlanPeriod.ToString(), out RentalPlanPeriodEnum result))
            return result;
        return RentalPlanPeriodEnum.None;
    }
    public RentalPlanPeriodEnum Convert(RentalPlanPeriodDtoEnum rentalPlanPeriod)
    {
        if (Enum.TryParse(rentalPlanPeriod.ToString(), out RentalPlanPeriodEnum result))
            return result;
        return RentalPlanPeriodEnum.None;
    }
}
