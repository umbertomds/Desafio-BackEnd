namespace MotorcycleRentalSystem.Domain.Contracts;

public interface IUnitOfWork
{
    Task Commit();
}
