using MotorcycleRentalSystem.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotorcycleRentalSystem.Domain.Entities;
public class Motorcycle : OrdinaryEntityBase
{
    public uint ManufacturedAt { get; set; }
    public string? Model { get; set; }
    public string? LicensePlate { get; set; }

    [InverseProperty("Motorcycle")]
    public List<RentOrder>? RentOrders { get; set; }

    [NotMapped]
    public bool IsLastOrderActive => RentOrders is not null && ActiveStates().Contains(RentOrders!.Last().State);
    private static List<RentOrderStateEnum> ActiveStates() => [RentOrderStateEnum.Active, RentOrderStateEnum.Late];
}
