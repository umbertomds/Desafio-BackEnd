using MotorcycleRentalSystem.Domain.Enums;

namespace MotorcycleRentalSystem.Domain.Entities;
public class Motorcycle : EntityBase
{
    public uint ManufacturedAt { get; set; }
    public string? Model { get; set; }
    public string? LicensePlate { get; set; }
    public virtual IEnumerable<RentOrder>? RentOrders { get; set; }
    public bool IsLastOrderActive => RentOrders is not null && ActiveStates().Contains(RentOrders!.Last().State);
    private static List<RentOrderStateEnum> ActiveStates() => [RentOrderStateEnum.Active, RentOrderStateEnum.Late];
}
