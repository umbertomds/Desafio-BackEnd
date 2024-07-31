using MotorcycleRentalSystem.Domain.Enums;
using MotorcycleRentalSystem.Domain.Mappings.Out;
using MotorcycleRentalSystem.DTO.Responses;
using MotorcycleRentalSystem.Domain.Services;
using MotorcycleRentalSystem.Exceptions;
using MotorcycleRentalSystem.Domain.Repositories;

namespace MotorcycleRentalSystem.Application.UseCases.RentQuotes.Read;

public class ReadRentQuotesUseCase(IUserRepository userRepository, IRentQuoteService rentQuoteService) : IReadRentQuotesUseCase
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IRentQuoteService _rentQuoteService = rentQuoteService;

    public GetPlansResponse Execute()
    {
        Dictionary<string, int> pairs = [];
        foreach (var value in Enum.GetValues<RentalPlanPeriodEnum>().Where(x => x != RentalPlanPeriodEnum.None))
            pairs.Add(NormatizeName(Enum.GetName(value)), (int)value);
        return new GetPlansResponseMapper().Map(pairs);
    }

    public CalculatePlanResponse Execute(RentalPlanPeriodEnum plan)
    {
        if (!Enum.GetValues<RentalPlanPeriodEnum>().Contains(plan))
            throw new EntityNotFoundException(
                "The requested plan was not found.", typeof(RentalPlanPeriodEnum), (long)plan
            );

        return new CalculatePlanResponseMapper().Map(_rentQuoteService.EstimatePlan(plan));
    }
    public CalculateFineResponse Execute(RentalPlanPeriodEnum planPeriod, DateTime estimated, DateTime actually)
    {
        if (!Enum.GetValues<RentalPlanPeriodEnum>().Contains(planPeriod))
            throw new EntityNotFoundException(
                "The requested plan was not found.", typeof(RentalPlanPeriodEnum), (long)planPeriod
            );

        var finePlan = _rentQuoteService.EstimatePlanFine(planPeriod, estimated, actually);
        return new CalculateFineResponseMapper().Map(finePlan, GetFineDescription(finePlan.FineType));
    }

    private static string NormatizeName(string? name)
    {
        if (name is null)
            return "";

        var list = name.ToCharArray().Select(x => x.ToString()).ToList();
        var normatized = list.Skip(1).Select(x => char.IsUpper(x[0]) ? " " + x.ToLower() : x);
        return string.Join("", [name.First(), .. normatized, " plan"]);
    }

    private static string GetFineDescription(PlanFineTypeEnum value) => value switch
    {
        PlanFineTypeEnum.LatenessFine => "Fine over the days beyond the deadline",
        PlanFineTypeEnum.FineOverRemainingDays => "Fine over the unused days before the deadline",
        _ => "There is no fine applied"
    };
}
