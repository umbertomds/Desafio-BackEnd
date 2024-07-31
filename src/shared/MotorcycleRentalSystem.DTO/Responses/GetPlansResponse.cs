using MotorcycleRentalSystem.DTO.ResponseObjects;

namespace MotorcycleRentalSystem.DTO.Responses;
public class GetPlansResponse : ResponseBase
{
    public List<PlanEntryDTO>? PlanEntries { get; set; }
}
