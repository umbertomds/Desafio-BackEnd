using Microsoft.AspNetCore.Mvc;
using MotorcycleRentalSystem.Api.Attributes;
using MotorcycleRentalSystem.Domain.Services;
using MotorcycleRentalSystem.Domain.Requests;
using MotorcycleRentalSystem.Domain.Entities;
using MotorcycleRentalSystem.Domain.Responses;
using Microsoft.Extensions.Options;
using MotorcycleRentalSystem.Domain.Options;
using MotorcycleRentalSystem.Application.UseCases.RentOrders.Create;
using MotorcycleRentalSystem.Exceptions;
using MotorcycleRentalSystem.Application.UseCases.RentOrders.Update;
using MotorcycleRentalSystem.Application.UseCases.RentOrders.Read;

namespace MotorcycleRentalSystem.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class RentOrdersController : ControllerBase
{
    [Authorize]
    [HttpGet]
    [ProducesResponseType(typeof(GetOrdersResponse), StatusCodes.Status200OK)]
    public IActionResult Get(
        [FromServices] IReadRentOrdersUseCase useCase, [FromQuery] int offset, [FromQuery] int quantity
    )
    {
        var user = HttpContext.Items["User"] as User;
        return Ok(useCase.Execute(user!.UserRole, user!.Id, offset, quantity));
    }

    [AdminAuth]
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(GetSelectedOrderResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(NotFoundResponse), StatusCodes.Status404NotFound)]
    public IActionResult GetById([FromServices] IReadRentOrdersUseCase useCase, [FromRoute] long id)
    {
        var path = HttpContext.Request.Path;
        GetSelectedOrderResponse? response = null;
        try
        {
            response = useCase.Execute(id);
            response.Path = path;
        }
        catch (EntityNotFoundException e)
        {
            return NotFound(new NotFoundResponse(e.Message, path));
        }
        return Ok(response);
    }

    [RegularAuth]
    [HttpPost]
    [ProducesResponseType(typeof(CreatedResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BadRequestResponse), StatusCodes.Status400BadRequest)]
    public IActionResult RegisterNew([FromServices] ICreateRentOrdersUseCase useCase, [FromBody] NewRentOrderRequest request)
    {
        CreatedResponse? response = null;
        var path = HttpContext.Request.Path;
        var user = HttpContext.Items["User"] as User;
        try
        {
            response = useCase.Execute(user!.Id, request);
        }
        catch (BusinessLogicValidationFaultException e)
        {
            return BadRequest(new BadRequestResponse(e.Message));
        }
        catch (FieldValidationFaultException e)
        {
            return BadRequest(new BadRequestResponse(e.Message, e.Field, e.Value?.ToString()));
        }
        return Created(path + "/" + response.Id, response);
    }

    [RegularAuth]
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(NotFoundResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(BadRequestResponse), StatusCodes.Status400BadRequest)]
    public IActionResult UpdateOrder(
        [FromServices] IUpdateRentOrdersUseCase useCase, [FromBody] UpdateOrderRequest request, 
        [FromQuery] long id
    )
    {
        var path = HttpContext.Request.Path;
        var user = HttpContext.Items["User"] as User;
        try
        {
            useCase.Execute(request, id, user!.Id);
        }
        catch (EntityNotFoundException e)
        {
            return NotFound(new NotFoundResponse(e.Message, path));
        }
        catch (BusinessLogicValidationFaultException e)
        {
            return BadRequest(new BadRequestResponse(e.Message));
        }
        catch (FieldValidationFaultException e)
        {
            return BadRequest(new BadRequestResponse(e.Message, e.Field, e.Value?.ToString()));
        }
        return Ok();
    }
}
