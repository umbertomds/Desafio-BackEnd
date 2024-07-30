using Microsoft.Extensions.Options;
using MotorcycleRentalSystem.Domain.Options;
using MotorcycleRentalSystem.Domain.Responses;
using MotorcycleRentalSystem.Domain.Requests;
using MotorcycleRentalSystem.Domain.Entities;
using MotorcycleRentalSystem.Domain.Services;

namespace MotorcycleRentalSystem.Infrastructure.Services;
public class UserService(ITokenService tokenService, IOptions<AppSettings> appSettings) : IUserService
{
    private long _idCounter = 0;
    private static List<User> _users =
    [
        new AdminUser()
        { 
            Id = 1, Name = "Tester admin", Username = "test", Password = "test" 
        }
    ];

    private readonly ITokenService _tokenService = tokenService;
    private readonly AppSettings _appSettings = appSettings.Value;

    public AuthenticateResponse? Authenticate(AuthenticateRequest model)
    {
        var secret = _appSettings.JwtAuthentication!.Secret ?? "";
        var user = _users.SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);
        if (user == null) 
            return null;

        var token = _tokenService.GetNewEncodedJwtToken(user, secret);
        return new AuthenticateResponse(user, token);
    }

    public IEnumerable<User> GetAll() => _users;

    public User? GetById(long id) => _users.FirstOrDefault(x => x.Id == id);

    public void AddNewUser(User user)
    {
        user.Id = getNewId();
        _users.Add(user);
    }

    public User? GetByUsername(string username) => _users.FirstOrDefault(x => x.Username == username);
    public User? GetByCnpj(string cnpj) => _users.OfType<DeliverymanUser>().FirstOrDefault(x => x.Cnpj == cnpj);
    public User? GetByLicenseNumber(string number) => _users.OfType<DeliverymanUser>().FirstOrDefault(x => x.DriverLicense?.Number == number);

    private long getNewId() => ++_idCounter;

}

