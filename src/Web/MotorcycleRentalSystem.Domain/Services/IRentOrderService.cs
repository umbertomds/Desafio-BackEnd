using MotorcycleRentalSystem.Domain.Entities;

namespace MotorcycleRentalSystem.Domain.Services;
public interface IRentOrderService
{
    IEnumerable<RentOrder> GetAll();
    void AddOrder(RentOrder order);
    RentOrder? GetById(long id);
}
