using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MotorcycleRentalSystem.Domain.Requests;
public class AuthenticateRequest
{
    [Required]
    [StringLength(100, MinimumLength = 4)]
    public string? Username { get; set; }

    [Required]
    [StringLength(20, MinimumLength = 4)]
    [DataType(DataType.Password)]
    public string? Password { get; set; }
}