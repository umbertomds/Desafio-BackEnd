namespace MotorcycleRentalSystem.DTO.Responses;
public class UnauthorizedAuthenticationResponse(string message, string username) : ResponseBase
{
    public string Message { get; set; } = message;
    public string Username { get; set; } = username;
}
