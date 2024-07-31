
namespace MotorcycleRentalSystem.DTO.Responses;
public class BadRequestResponse(string message, string? field = null, string? value = null) : ResponseBase
{
    public string Message { get; set; } = message;
    public string? ErrorField { get; set; } = field;
    public string? FieldValue { get; set; } = value;
}
