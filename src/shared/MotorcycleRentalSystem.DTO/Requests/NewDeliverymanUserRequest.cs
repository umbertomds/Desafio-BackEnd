using MotorcycleRentalSystem.DTO.Enums;
using System.ComponentModel.DataAnnotations;

namespace MotorcycleRentalSystem.DTO.Requests;
public class NewDeliverymanUserRequest
{
    [Required]
    [StringLength(100, MinimumLength = 4)]
    public string? Username { get; set; }
    [Required]
    [StringLength(20, MinimumLength = 4)]
    [DataType(DataType.Password)] 
    public string? Password { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Compare("Password")]
    public string? ConfirmPassword { get; set; }

    [Required]
    [StringLength(14, MinimumLength = 14)]
    [DataType(DataType.Text)]
    [RegularExpression("^[0-9]+")]
    public string? Cnpj { get; set; }
    [Required]
    [StringLength(11, MinimumLength = 9)]
    [DataType(DataType.Text)]
    [RegularExpression("^[0-9]+")]
    public string? DriverLicenseNumber { get; set; }
    [Required]
    public LicenseTypeDtoEnum DriverLicenseType { get; set; }
    [Required] 
    [StringLength(255, MinimumLength = 6)]
    [DataType(DataType.ImageUrl)]
    public string? DriverLicensePicture { get; set; }

    public DateTime DateOfBirth { get; set; }

    [StringLength(80, MinimumLength = 3)]
    public string? Name { get; set; }
}
