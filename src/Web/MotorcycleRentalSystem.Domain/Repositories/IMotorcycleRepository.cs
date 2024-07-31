using MotorcycleRentalSystem.Domain.Entities;

namespace MotorcycleRentalSystem.Domain.Repositories;
public interface IMotorcycleRepository
{
    Task<List<Motorcycle>> GetAll();
    Task<Motorcycle?> GetById(long id);
    Task<Motorcycle?> GetByLicensePlateNumber(string plateNumber);
    Task Add(Motorcycle motorcycle);
    Task Remove(long id);
}
