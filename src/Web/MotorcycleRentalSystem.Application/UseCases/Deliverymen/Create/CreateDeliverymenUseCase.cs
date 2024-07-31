using MotorcycleRentalSystem.DTO.Requests;
using MotorcycleRentalSystem.Domain.Entities;
using MotorcycleRentalSystem.Domain.Mappings.In;
using MotorcycleRentalSystem.Exceptions;
using MotorcycleRentalSystem.Domain.Repositories;

namespace MotorcycleRentalSystem.Application.UseCases.Deliverymen.Create;

public class CreateDeliverymenUseCase(IUserRepository userRepository) : ICreateDeliverymenUseCase
{
    private readonly ToLicenseTypeEnum licenseTypeEnum = new();
    private readonly IUserRepository _userRepository = userRepository;
    public async Task<long> Execute(NewDeliverymanUserRequest request)
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
        user.DriverLicense.Type = licenseTypeEnum.Convert(request.DriverLicenseType);
        user.DriverLicense.Picture = request.DriverLicensePicture;
        await _userRepository.Add(user);

        return user.Id;
    }

    private void Validate(NewDeliverymanUserRequest request)
    {
        string mot = "";
        string field = "";
        string value = "";

        if (_userRepository.GetByUsername(request.Username!) is not null)
        {
            mot = "The requested username is already in use. Pick another one.";
            field = "Username";
            value = request.Username!;
        }
        else if (_userRepository.GetByCnpj(request.Cnpj!) is not null)
        {
            mot = "The requested CNPJ is already in use. Contact us for further information and next steps.";
            field = "Cnpj";
            value = request.Cnpj!;
        }
        else if (_userRepository.GetByLicenseNumber(request.DriverLicenseNumber!) is not null)
        {
            mot = "The requested driver license number is already in use. Contact us for further information and next steps.";
            field = "DriverLicenseNumber";
            value = request.DriverLicenseNumber!;
        }

        if (mot != "")
            throw new FieldValidationFaultException(mot, field, value);
    }
}
