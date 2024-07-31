using MotorcycleRentalSystem.DTO.ResponseObjects;
using MotorcycleRentalSystem.DTO.Responses;

namespace MotorcycleRentalSystem.Domain.Mappings.Out;

public class GetPlansResponseMapper
{
    public GetPlansResponse Map(Dictionary<string, int> dictionaryEntries) => new()
    {
        PlanEntries =
        [
            .. dictionaryEntries.Select(x => new PlanEntryDTO() { PlanName = x.Key, PlanDays = x.Value })
        ]
    };
}