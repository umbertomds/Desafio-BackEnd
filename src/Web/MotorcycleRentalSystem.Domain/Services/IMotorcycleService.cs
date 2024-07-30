using MotorcycleRentalSystem.Domain.Entities;

namespace MotorcycleRentalSystem.Domain.Services;
public interface IMotorcycleService
{
    IEnumerable<Motorcycle> GetAll();
    Motorcycle? GetById(long id);
    Motorcycle? GetByLicensePlateNumber(string plateNumber);
    void Add(Motorcycle motorcycle);
    void Remove(long id);
}
