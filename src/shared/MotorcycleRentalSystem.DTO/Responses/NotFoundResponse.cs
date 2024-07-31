namespace MotorcycleRentalSystem.DTO.Responses;
public class NotFoundResponse(string message, string path) : ResponseBase
{
    public string Message { get; set; } = message;
    public string Path { get; set; } = path;
}
