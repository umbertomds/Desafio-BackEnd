namespace MotorcycleRentalSystem.Domain.Entities;
public class EntityBase
{
    public long Id { get; set; }
    public DateTime CreateAt { get; set; }
    public DateTime ModifiedAt { get; set; }
}
