using MotorcycleRentalSystem.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotorcycleRentalSystem.Domain.Entities;

[Table("Users")]
public class User
{
    [Key]
    public long Id { get; set; }
    [Timestamp]
    public DateTime CreateAt { get; set; } = DateTime.MinValue;
    [Timestamp]
    public DateTime ModifiedAt { get; set; } = DateTime.MinValue;

    public string? Username { get; set; }
    public virtual UserRoleEnum UserRole { get; set; }
    public string? Name { get; set; }
    public string? Password { get; set; } 
}