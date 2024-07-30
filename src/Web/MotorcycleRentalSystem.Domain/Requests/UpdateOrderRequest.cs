using System.ComponentModel.DataAnnotations;

namespace MotorcycleRentalSystem.Domain.Requests;
public class UpdateOrderRequest
{
    [Required] 
    public long Id { get; set; }
    [Required] 
    public DateTime EndAtDate { get; set; }
}
