using MotorcycleRentalSystem.Domain.Entities;
using MotorcycleRentalSystem.Domain.Services;

namespace MotorcycleRentalSystem.Infrastructure.Services;
public class MotorcycleService : IMotorcycleService
{
    private long _idCounter = 0;
    private static readonly List<Motorcycle> _motorcycles = [];

    public void AddNewMotorcycle(Motorcycle motorcycle)
    {
        motorcycle.Id = getNewId();
        _motorcycles.Add(motorcycle);
    }

    public void DeleteMotorcycle(long id)
    {
        var moto = _motorcycles.FirstOrDefault(x => x.Id == id);
        if (moto is not null)
            _motorcycles.Remove(moto);
    }
    public IEnumerable<Motorcycle> GetAll() => _motorcycles;

    public Motorcycle? GetById(long id) => _motorcycles.FirstOrDefault(x => x.Id == id);

    public Motorcycle? GetByLicensePlateNumber(string plateNumber) => _motorcycles.FirstOrDefault(x => x.LicensePlate == plateNumber);

    private long getNewId() => ++_idCounter;
}
