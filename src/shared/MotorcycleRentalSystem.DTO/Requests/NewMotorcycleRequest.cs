using System.ComponentModel.DataAnnotations;

namespace MotorcycleRentalSystem.DTO.Requests;
public class NewMotorcycleRequest
{
    [Required]
    [StringLength(4, MinimumLength = 4)]
    [DataType(DataType.Text)]
    [RegularExpression("^(20|19){1}([0-9]){2}")]
    public string? ManufacturingYear { get; set; }
    [Required]
    [StringLength(50, MinimumLength = 3)]
    [DataType(DataType.Text)]
    public string? Model { get; set; }
    [Required]
    [StringLength(7, MinimumLength = 7)]
    [DataType(DataType.Text)]
    [RegularExpression("^[A-z0-9]+")]
    public string? LicensePlate { get; set; }
}
