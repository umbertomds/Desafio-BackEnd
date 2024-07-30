using MotorcycleRentalSystem.Domain.Contracts;
using MotorcycleRentalSystem.Domain.Entities;
using MotorcycleRentalSystem.Domain.Services;
using MotorcycleRentalSystem.Infrastructure.Context;

namespace MotorcycleRentalSystem.Infrastructure.Services;
public class MotorcycleService(AppDbContext appDbContext, IUnitOfWork unitOfWork) : IMotorcycleService
{
    private readonly AppDbContext _dbContext = appDbContext;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    
    public void Add(Motorcycle motorcycle)
    {
        _dbContext.Motorcycles.Add(motorcycle);
        _unitOfWork.Commit();
    }

    public void Remove(long id)
    {
        var moto = _dbContext.Motorcycles.FirstOrDefault(x => x.Id == id);
        if (moto is not null)
        {
            _dbContext.Motorcycles.Remove(moto);
            _unitOfWork.Commit();
        }
    }

    public IEnumerable<Motorcycle> GetAll() => _dbContext.Motorcycles.AsEnumerable();

    public Motorcycle? GetById(long id) => _dbContext.Motorcycles.FirstOrDefault(x => x.Id == id);

    public Motorcycle? GetByLicensePlateNumber(string plateNumber) => _dbContext.Motorcycles.FirstOrDefault(x => x.LicensePlate == plateNumber);
}
