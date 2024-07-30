using Microsoft.AspNetCore.Mvc;
using MotorcycleRentalSystem.Api.Attributes;
using MotorcycleRentalSystem.Domain.Requests;
using MotorcycleRentalSystem.Domain.Entities;
using MotorcycleRentalSystem.Domain.Responses;
using MotorcycleRentalSystem.Application.UseCases.Deliverymen.Update;
using MotorcycleRentalSystem.Application.UseCases.Deliverymen.Create;
using MotorcycleRentalSystem.Exceptions;

namespace MotorcycleRentalSystem.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class DeliverymenController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(BadRequestResponse), StatusCodes.Status400BadRequest)]
    public IActionResult RegisterNew([FromServices] ICreateDeliverymenUseCase useCase, [FromBody] NewDeliverymanUserRequest request)
    {
        string path = HttpContext.Request.Path;
        try
        {
            var createdId = useCase.Execute(request);
            return Created(path + "/" + createdId.ToString(), new CreatedResponse(createdId));
        }
        catch (FieldValidationFaultException e)
        {
            return BadRequest(new BadRequestResponse(e.Message, e.Field, e.Value?.ToString()));
        }
    }

    [RegularAuth]
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult UpdateDriverLicensePicture([FromServices] IUpdateDeliverymenUseCase useCase, [FromBody] UpdateDriverLicenseRequest request)
    {
        var user = (DeliverymanUser)HttpContext.Items["User"]!;
        useCase.Execute(request, user.Id);
        return Ok();
    }
}