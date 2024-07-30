using System.ComponentModel.DataAnnotations;

namespace MotorcycleRentalSystem.Domain.Requests;
public class UpdateDriverLicenseRequest
{
    [Required]
    [StringLength(255, MinimumLength = 6)]
    [DataType(DataType.ImageUrl)]
    public string? DriverLicensePicture { get; set; }
}
