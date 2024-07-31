using System.ComponentModel.DataAnnotations;

namespace MotorcycleRentalSystem.DTO.Requests;
public class UpdateLicensePlateRequest
{
    [Required]
    [StringLength(7, MinimumLength = 7)]
    [DataType(DataType.Text)]
    [RegularExpression("^[A-z0-9]+")]
    public string? NewLicensePlate { get; set; }
}
