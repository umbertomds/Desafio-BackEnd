using MotorcycleRentalSystem.Domain.Entities;
using MotorcycleRentalSystem.Domain.Repositories;
using MotorcycleRentalSystem.DTO.Requests;
namespace MotorcycleRentalSystem.Application.UseCases.Deliverymen.Update;

public class UpdateDeliverymenUseCase(IUserRepository userRepository) : IUpdateDeliverymenUseCase
{
    private readonly IUserRepository _userRepository = userRepository;
    public async Task Execute(UpdateDriverLicenseRequest request, long id)
    {
        var user = await _userRepository.GetById(id) as DeliverymanUser;
        var license = user?.DriverLicense;
        if (license is not null)
            license.Picture = request.DriverLicensePicture;
    }
}
