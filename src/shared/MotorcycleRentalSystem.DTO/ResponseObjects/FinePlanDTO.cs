using MotorcycleRentalSystem.DTO.Enums;

namespace MotorcycleRentalSystem.DTO.ResponseObjects;
public class FinePlanDTO
{
    public PlanFineTypeDtoEnum FineType { get; set; }
    public int Days { get; set; }
    public decimal PerDay { get; set; }
    public decimal Total { get; set; }
}
