namespace MotorcycleRentalSystem.Exceptions;

public class EntityNotFoundException(string message, Type type, long id) : ApplicationExceptionBase(message)
{
    public Type Type { get; private set; } = type;
    public long Id { get; private set; } = id;
}
