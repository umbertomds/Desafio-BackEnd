namespace MotorcycleRentalSystem.Domain.Options;
public class JwtAuthentication
{
    public string? Secret { get; set; }
    public int TokenExpiration { get; set; }
    public int ClockSkew { get; set; }
}
