using MotorcycleRentalSystem.Domain.Contracts;
using MotorcycleRentalSystem.Domain.Entities;
using MotorcycleRentalSystem.Domain.Services;
using MotorcycleRentalSystem.Infrastructure.Context;

namespace MotorcycleRentalSystem.Infrastructure.Services;

public class RentOrderService(AppDbContext appDbContext, IUnitOfWork unitOfWork, IRentQuoteService rentQuoteService) : IRentOrderService
{
    private readonly AppDbContext _dbContext = appDbContext;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IRentQuoteService _rentQuoteService = rentQuoteService;

    public void Add(RentOrder order)
    {
        _dbContext.RentOrders.Add(order);
        _unitOfWork.Commit();
    }

    public IEnumerable<RentOrder> GetAll() => _dbContext.RentOrders.AsEnumerable();

    public RentOrder? GetById(long id) => _dbContext.RentOrders.FirstOrDefault(x => x.Id == id);
}
