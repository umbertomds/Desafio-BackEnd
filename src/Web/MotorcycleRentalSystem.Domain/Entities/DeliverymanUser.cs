using MotorcycleRentalSystem.Domain.Enums;

namespace MotorcycleRentalSystem.Domain.Entities;

public class DeliverymanUser : User
{
    public string? Cnpj { get; set; }
    public override UserRoleEnum UserRole { get => UserRoleEnum.RegularRole; set => _ = value; }
    public virtual DriverLicense DriverLicense { get; set; } = new();
    public DateTime DateOfBirth { get; set; }
    public virtual IEnumerable<RentOrder>? RentOrders { get; set; }
    public bool IsLastOrderActive => RentOrders is not null && ActiveStates().Contains(RentOrders!.Last().State);
    private static List<RentOrderStateEnum> ActiveStates() => [RentOrderStateEnum.Active, RentOrderStateEnum.Late];
}
