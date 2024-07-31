using MotorcycleRentalSystem.Domain.Enums;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotorcycleRentalSystem.Domain.Entities;

public class DeliverymanUser : User
{
    [Required]
    public string? Cnpj { get; set; }
    [NotMapped]
    public override UserRoleEnum UserRole { get => UserRoleEnum.RegularRole; set => _ = value; }
    public DriverLicense DriverLicense { get; set; } = new();
    public DateTime DateOfBirth { get; set; }

    [InverseProperty("Deliveryman")]
    public List<RentOrder>? RentOrders { get; set; }
    [NotMapped]
    public bool IsLastOrderActive => RentOrders is not null && ActiveStates().Contains(RentOrders!.Last().State);
    private static List<RentOrderStateEnum> ActiveStates() => [RentOrderStateEnum.Active, RentOrderStateEnum.Late];
}
