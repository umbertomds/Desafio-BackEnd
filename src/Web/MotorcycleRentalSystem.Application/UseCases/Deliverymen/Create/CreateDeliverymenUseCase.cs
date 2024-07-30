using MotorcycleRentalSystem.Domain.Entities;
using MotorcycleRentalSystem.Domain.Requests;
using MotorcycleRentalSystem.Domain.Services;
using MotorcycleRentalSystem.Exceptions;

namespace MotorcycleRentalSystem.Application.UseCases.Deliverymen.Create;

public class CreateDeliverymenUseCase(IUserService userService) : ICreateDeliverymenUseCase
{
    private readonly IUserService _userService = userService;
    public long Execute(NewDeliverymanUserRequest request)
    {
        Validate(request);

        DeliverymanUser user = new()
        {
            Username = request.Username,
            Password = request.Password,
            Cnpj = request.Cnpj,
            DateOfBirth = request.DateOfBirth,
            Name = request.Name
        };
        user.DriverLicense.Number = request.DriverLicenseNumber;
        user.DriverLicense.Type = request.DriverLicenseType;
        user.DriverLicense.Picture = request.DriverLicensePicture;
        _userService.Add(user);

        return user.Id;
    }

    private void Validate(NewDeliverymanUserRequest request)
    {
        string mot = "";
        string field = "";
        string value = "";

        if (_userService.GetByUsername(request.Username!) is not null)
        {
            mot = "The requested username is already in use. Pick another one.";
            field = "Username";
            value = request.Username!;
        }
        else if (_userService.GetByCnpj(request.Cnpj!) is not null)
        {
            mot = "The requested CNPJ is already in use. Contact us for further information and next steps.";
            field = "Cnpj";
            value = request.Cnpj!;
        }
        else if (_userService.GetByLicenseNumber(request.DriverLicenseNumber!) is not null)
        {
            mot = "The requested driver license number is already in use. Contact us for further information and next steps.";
            field = "DriverLicenseNumber";
            value = request.DriverLicenseNumber!;
        }

        if (mot != "")
            throw new FieldValidationFaultException(mot, field, value);
    }
}
