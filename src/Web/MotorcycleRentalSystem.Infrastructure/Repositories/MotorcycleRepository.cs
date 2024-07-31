using Microsoft.EntityFrameworkCore;
using MotorcycleRentalSystem.Domain.Contracts;
using MotorcycleRentalSystem.Domain.Entities;
using MotorcycleRentalSystem.Domain.Repositories;
using MotorcycleRentalSystem.Infrastructure.Context;

namespace MotorcycleRentalSystem.Infrastructure.Repositories;
public class MotorcycleRepository(AppDbContext appDbContext, IUnitOfWork unitOfWork) : IMotorcycleRepository
{
    private readonly AppDbContext _dbContext = appDbContext;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task Add(Motorcycle motorcycle)
    {
        _dbContext.Motorcycles.Add(motorcycle);
        await _unitOfWork.Commit();
    }

    public async Task Remove(long id)
    {
        var moto = await _dbContext.Motorcycles.FirstOrDefaultAsync(x => x.Id == id);
        if (moto is not null)
        {
            _dbContext.Motorcycles.Remove(moto);
            await _unitOfWork.Commit();
        }
    }

    public async Task<List<Motorcycle>> GetAll() => await _dbContext.Motorcycles.ToListAsync();

    public async Task<Motorcycle?> GetById(long id) => await _dbContext.Motorcycles.FirstOrDefaultAsync(x => x.Id == id);

    public async Task<Motorcycle?> GetByLicensePlateNumber(string plateNumber) => await _dbContext.Motorcycles.FirstOrDefaultAsync(x => x.LicensePlate == plateNumber);
}
