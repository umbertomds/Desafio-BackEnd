namespace MotorcycleRentalSystem.Domain.Responses;
public class GetPlansResponse : ResponseBase
{
    public class PlanEntry
    {
        public string? PlanName { get; set; }
        public int PlanDays { get; set; }
    }

    public GetPlansResponse(Dictionary<string, int> dictionaryEntries)
    {
        PlanEntries = 
        [
            .. dictionaryEntries.Select(x => new PlanEntry() { PlanName = x.Key, PlanDays = x.Value })
        ];
    }

    public List<PlanEntry> PlanEntries { get; set; }
}
