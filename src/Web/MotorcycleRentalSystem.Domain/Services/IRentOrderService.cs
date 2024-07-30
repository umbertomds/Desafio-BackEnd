using MotorcycleRentalSystem.Domain.Entities;

namespace MotorcycleRentalSystem.Domain.Services;
public interface IRentOrderService
{
    IEnumerable<RentOrder> GetAll();
    void Add(RentOrder order);
    RentOrder? GetById(long id);
}
