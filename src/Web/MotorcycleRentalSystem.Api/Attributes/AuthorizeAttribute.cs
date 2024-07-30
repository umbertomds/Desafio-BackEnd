using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MotorcycleRentalSystem.Domain.Entities;

namespace MotorcycleRentalSystem.Api.Attributes;
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeAttribute : Attribute, IAuthorizationFilter
{
    protected static JsonResult UnauthorizedResult = 
    new(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };

    protected User? UserObject = null;

    public virtual void OnAuthorization(AuthorizationFilterContext context)
    {
        UserObject = context.HttpContext.Items["User"] as User;
        if (UserObject is null)
            context.Result = UnauthorizedResult;
    }
}