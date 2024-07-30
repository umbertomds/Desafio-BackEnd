using Microsoft.Extensions.Options;
using MotorcycleRentalSystem.Domain.Options;
using MotorcycleRentalSystem.Domain.Responses;
using MotorcycleRentalSystem.Domain.Requests;
using MotorcycleRentalSystem.Domain.Entities;
using MotorcycleRentalSystem.Domain.Services;
using MotorcycleRentalSystem.Domain.Contracts;
using MotorcycleRentalSystem.Infrastructure.Context;

namespace MotorcycleRentalSystem.Infrastructure.Services;
public class UserService(ITokenService tokenService, AppDbContext appDbContext, IUnitOfWork unitOfWork, IOptions<AppSettings> appSettings) : IUserService
{
    private readonly AppDbContext _dbContext = appDbContext;
    private readonly AppSettings _appSettings = appSettings.Value;
    private readonly ITokenService _tokenService = tokenService;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public AuthenticateResponse? Authenticate(AuthenticateRequest model)
    {
        var secret = _appSettings.JwtAuthentication!.Secret ?? "";
        var sw = _dbContext.AdminUsers.ToList();
        var user = _dbContext.Users.SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);
        if (user == null) 
            return null;

        var token = _tokenService.GetNewEncodedJwtToken(user, secret);
        return new AuthenticateResponse(user, token);
    }

    public IEnumerable<User> GetAll() => _dbContext.Users.AsEnumerable();

    public User? GetById(long id) => _dbContext.Users.FirstOrDefault(x => x.Id == id);

    public void Add(User user)
    {
        _dbContext.Add(user);
        _unitOfWork.Commit();
    }

    public User? GetByUsername(string username) => _dbContext.Users.FirstOrDefault(x => x.Username == username);
    public User? GetByCnpj(string cnpj) => _dbContext.Users.OfType<DeliverymanUser>().FirstOrDefault(x => x.Cnpj == cnpj);
    public User? GetByLicenseNumber(string number) => _dbContext.Users.OfType<DeliverymanUser>().FirstOrDefault(x => x.DriverLicense.Number == number);
}

