namespace MotorcycleRentalSystem.Domain.Options;
public class AppSettings
{
    public bool? UseSwagger { get; set; }
    public JwtAuthentication? JwtAuthentication { get; set; }
    public WideQueries? WideQueries { get; set; }
}