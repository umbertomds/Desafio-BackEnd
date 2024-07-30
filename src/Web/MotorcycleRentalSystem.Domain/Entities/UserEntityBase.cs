using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MotorcycleRentalSystem.Domain.Entities;
public class UserEntityBase
{
    [Key]
    public long Id { get; set; }
    [Timestamp]
    public DateTime CreateAt { get; set; } = DateTime.MinValue;
    [Timestamp]
    public DateTime ModifiedAt { get; set; } = DateTime.MinValue;
}
