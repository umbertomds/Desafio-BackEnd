using MotorcycleRentalSystem.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotorcycleRentalSystem.Domain.Entities;

public class DeliverymanUser : User
{
    public string? Cnpj { get; set; }
    [NotMapped]
    public override UserRoleEnum UserRole { get => UserRoleEnum.RegularRole; set => _ = value; }
    public DriverLicense DriverLicense { get; set; } = new();
    public DateTime DateOfBirth { get; set; }
    public virtual IEnumerable<RentOrder>? RentOrders { get; set; }
    [NotMapped]
    public bool IsLastOrderActive => RentOrders is not null && ActiveStates().Contains(RentOrders!.Last().State);
    private static List<RentOrderStateEnum> ActiveStates() => [RentOrderStateEnum.Active, RentOrderStateEnum.Late];
}
