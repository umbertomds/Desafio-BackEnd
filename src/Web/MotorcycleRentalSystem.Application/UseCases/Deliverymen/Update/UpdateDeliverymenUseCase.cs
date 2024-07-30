using MotorcycleRentalSystem.Domain.Entities;
using MotorcycleRentalSystem.Domain.Requests;
using MotorcycleRentalSystem.Domain.Services;
namespace MotorcycleRentalSystem.Application.UseCases.Deliverymen.Update;

public class UpdateDeliverymenUseCase(IUserService userService) : IUpdateDeliverymenUseCase
{
    private readonly IUserService _userService = userService;
    public void Execute(UpdateDriverLicenseRequest request, long id)
    {
        var user = _userService.GetById(id) as DeliverymanUser;
        var license = user?.DriverLicense;
        if (license is not null)
            license.Picture = request.DriverLicensePicture;
    }
}
