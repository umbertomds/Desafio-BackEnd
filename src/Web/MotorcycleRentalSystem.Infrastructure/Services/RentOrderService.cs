using MotorcycleRentalSystem.Domain.Entities;
using MotorcycleRentalSystem.Domain.Services;


namespace MotorcycleRentalSystem.Infrastructure.Services;

public class RentOrderService(IRentQuoteService rentQuoteService) : IRentOrderService
{
    private long _idCounter = 0;
    private static readonly List<RentOrder> _rentOrders = [];
    private readonly IRentQuoteService _rentQuoteService = rentQuoteService;

    public void AddOrder(RentOrder order)
    {
        order.Id = getNewId();
        _rentOrders.Add(order);
    }

    public IEnumerable<RentOrder> GetAll() => _rentOrders;

    public RentOrder? GetById(long id) => _rentOrders.FirstOrDefault(x => x.Id == id);

    private long getNewId() => ++_idCounter;
}
