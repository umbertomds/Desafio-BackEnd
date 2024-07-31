using MotorcycleRentalSystem.Domain.Entities;

namespace MotorcycleRentalSystem.Domain.Repositories;
public interface IRentOrderRepository
{
    Task<IEnumerable<RentOrder>> GetAll();
    Task Add(RentOrder order);
    Task<RentOrder?> GetById(long id);
}
