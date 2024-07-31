using MotorcycleRentalSystem.DTO.Enums;
using MotorcycleRentalSystem.Domain.Enums;

namespace MotorcycleRentalSystem.Domain.Mappings.In;

public class ToLicenseTypeEnum
{
    public LicenseTypeEnum Convert(int licenseType)
    {
        if (Enum.TryParse(licenseType.ToString(), out LicenseTypeEnum result))
            return result;
        return LicenseTypeEnum.None;
    }

    public LicenseTypeEnum Convert(LicenseTypeDtoEnum licenseType)
    {
        if (Enum.TryParse(licenseType.ToString(), out LicenseTypeEnum result))
            return result;
        return LicenseTypeEnum.None;
    }
}
