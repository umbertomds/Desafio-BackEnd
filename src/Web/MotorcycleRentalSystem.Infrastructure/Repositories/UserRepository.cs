using Microsoft.Extensions.Options;
using MotorcycleRentalSystem.Domain.Options;
using MotorcycleRentalSystem.Domain.Entities;
using MotorcycleRentalSystem.Domain.Services;
using MotorcycleRentalSystem.Domain.Contracts;
using MotorcycleRentalSystem.Infrastructure.Context;
using MotorcycleRentalSystem.Domain.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MotorcycleRentalSystem.Infrastructure.Repositories;
public class UserRepository(ITokenService tokenService, IPasswordHasher<User> passwordHasher, AppDbContext appDbContext, IUnitOfWork unitOfWork, IOptions<AppSettings> appSettings) : IUserRepository
{
    private readonly AppDbContext _dbContext = appDbContext;
    private readonly AppSettings _appSettings = appSettings.Value;
    private readonly ITokenService _tokenService = tokenService;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IPasswordHasher<User> _passwordHasher = passwordHasher;
    public async Task<List<User>> GetAll() => await _dbContext.Users.ToListAsync();

    public async Task<User?> GetById(long id) => await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

    public async Task Add(User user)
    {
        user.Password = _passwordHasher.HashPassword(user, user.Password!);
        _dbContext.Add(user);
        await _unitOfWork.Commit();
    }

    public async Task<User?> GetByUsername(string username) => await _dbContext.Users.FirstOrDefaultAsync(x => x.Username == username);
    public async Task<User?> GetByCnpj(string cnpj) => await _dbContext.Users.OfType<DeliverymanUser>().FirstOrDefaultAsync(x => x.Cnpj == cnpj);
    public async Task<User?> GetByLicenseNumber(string number) => await _dbContext.Users.OfType<DeliverymanUser>().FirstOrDefaultAsync(x => x.DriverLicense.Number == number);
}

