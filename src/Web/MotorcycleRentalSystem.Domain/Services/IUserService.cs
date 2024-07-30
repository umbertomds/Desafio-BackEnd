using MotorcycleRentalSystem.Domain.Responses;
using MotorcycleRentalSystem.Domain.Requests;
using MotorcycleRentalSystem.Domain.Entities;

namespace MotorcycleRentalSystem.Domain.Services;
public interface IUserService
{
    AuthenticateResponse? Authenticate(AuthenticateRequest model);
    IEnumerable<User> GetAll();
    User? GetById(long id);
    User? GetByUsername(string username);
    User? GetByCnpj(string cnpj);
    User? GetByLicenseNumber(string number);
    void Add(User user);
}
