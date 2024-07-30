using MotorcycleRentalSystem.Domain.Entities;
using MotorcycleRentalSystem.Domain.Enums;
using MotorcycleRentalSystem.Domain.Services;

namespace MotorcycleRentalSystem.Infrastructure.Services;
public class RentQuoteService : IRentQuoteService
{
    public RentPlan EstimatePlan(RentalPlanPeriodEnum planPeriod)
    {
        decimal perDay = planPeriod switch
        {
            RentalPlanPeriodEnum.SevenDays => 30,
            RentalPlanPeriodEnum.FifteenDays => 28,
            RentalPlanPeriodEnum.ThirdyDays => 22,
            RentalPlanPeriodEnum.FourtyFiveDays => 20,
            RentalPlanPeriodEnum.FiftyDays => 18,
            _ => 0,
        };
        return new() { PlanPeriod = planPeriod, PerDayCost = perDay, TotalCost = ((int)planPeriod) * perDay };
    }

    public FinePlan EstimatePlanFine(RentalPlanPeriodEnum planPeriod, DateTime estimated, DateTime actually)
    {
        var determinedPlan = PlanFineTypeEnum.None;
        decimal perDay = 0;
        int days = 0;

        if (planPeriod == RentalPlanPeriodEnum.None || estimated == actually)
            return new() { FineType = PlanFineTypeEnum.None };

        if (estimated > actually)
        {
            days = estimated.Subtract(actually).Days;
            var perDayPercentage = planPeriod == RentalPlanPeriodEnum.SevenDays ? 0.2M : 0.4M;
            var perDayPrincipal = EstimatePlan(planPeriod).PerDayCost;
            perDay = perDayPrincipal * perDayPercentage;
            determinedPlan = PlanFineTypeEnum.FineOverRemainingDays;
        }
        else
        {
            days = actually.Subtract(estimated).Days;
            perDay = 50;
            determinedPlan = PlanFineTypeEnum.LatenessFine;
        }
        return new() { FineType = determinedPlan, Days = days, PerDay = perDay, Total = days * perDay };
    }
}
