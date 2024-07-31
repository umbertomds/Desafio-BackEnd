using MotorcycleRentalSystem.Domain.Enums;
using MotorcycleRentalSystem.DTO.Responses;

namespace MotorcycleRentalSystem.Application.UseCases.RentQuotes.Read;
public interface IReadRentQuotesUseCase
{
    GetPlansResponse Execute();
    CalculatePlanResponse Execute(RentalPlanPeriodEnum plan);
    CalculateFineResponse Execute(RentalPlanPeriodEnum planPeriod, DateTime estimated, DateTime actually);
}
