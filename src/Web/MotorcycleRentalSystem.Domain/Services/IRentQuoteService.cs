using MotorcycleRentalSystem.Domain.Entities;
using MotorcycleRentalSystem.Domain.Enums;

namespace MotorcycleRentalSystem.Domain.Services;
public interface IRentQuoteService
{
    RentPlan EstimatePlan(RentalPlanPeriodEnum planPeriod);
    FinePlan EstimatePlanFine(RentalPlanPeriodEnum planPeriod, DateTime estimated, DateTime actually);
}
