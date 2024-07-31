using MotorcycleRentalSystem.Domain.Entities;

namespace MotorcycleRentalSystem.Domain.Repositories;
public interface IUserRepository
{
    Task<List<User>> GetAll();
    Task<User?> GetById(long id);
    Task<User?> GetByUsername(string username);
    Task<User?> GetByCnpj(string cnpj);
    Task<User?> GetByLicenseNumber(string number);
    Task Add(User user);
}
