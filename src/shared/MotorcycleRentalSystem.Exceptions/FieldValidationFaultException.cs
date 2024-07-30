namespace MotorcycleRentalSystem.Exceptions;

public class FieldValidationFaultException(string message, string? field = null, object? value = null) : ApplicationExceptionBase(message)
{
    public string? Field { get; set; } = field;
    public object? Value { get; set; } = value;
}
