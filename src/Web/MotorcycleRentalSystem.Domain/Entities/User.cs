using System.Text.Json.Serialization;
using MotorcycleRentalSystem.Domain.Enums;

namespace MotorcycleRentalSystem.Domain.Entities;
public class User : UserEntityBase
{
    public string? Username { get; set; }
    public virtual UserRoleEnum UserRole { get; set; }
    public string? Name { get; set; }
    [JsonIgnore] public string? Password { get; set; } 
}