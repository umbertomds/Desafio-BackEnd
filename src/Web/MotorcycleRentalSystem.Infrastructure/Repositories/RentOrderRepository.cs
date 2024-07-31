using Microsoft.EntityFrameworkCore;
using MotorcycleRentalSystem.Domain.Contracts;
using MotorcycleRentalSystem.Domain.Entities;
using MotorcycleRentalSystem.Domain.Repositories;
using MotorcycleRentalSystem.Domain.Services;
using MotorcycleRentalSystem.Infrastructure.Context;

namespace MotorcycleRentalSystem.Infrastructure.Repositories;

public class RentOrderRepository(AppDbContext appDbContext, IUnitOfWork unitOfWork, IRentQuoteService rentQuoteService) : IRentOrderRepository
{
    private readonly AppDbContext _dbContext = appDbContext;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IRentQuoteService _rentQuoteService = rentQuoteService;

    public async Task Add(RentOrder order)
    {
        _dbContext.Add(order);
        await _unitOfWork.Commit();
    }

    public async Task<IEnumerable<RentOrder>> GetAll() => await _dbContext.RentOrders.ToListAsync();

    public async Task<RentOrder?> GetById(long id) => await _dbContext.RentOrders.FirstOrDefaultAsync(x => x.Id == id);
}
