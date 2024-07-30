using Microsoft.AspNetCore.Mvc.Filters;
using MotorcycleRentalSystem.Domain.Enums;

namespace MotorcycleRentalSystem.Api.Attributes;

public class RegularAuthAttribute : AuthorizeAttribute
{
    public override void OnAuthorization(AuthorizationFilterContext context)
    {
        base.OnAuthorization(context);
        if (UserObject is null || UserObject?.UserRole != UserRoleEnum.RegularRole)
            context.Result = UnauthorizedResult;
    }
}
