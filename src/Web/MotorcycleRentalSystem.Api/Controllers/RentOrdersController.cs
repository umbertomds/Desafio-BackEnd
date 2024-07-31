using Microsoft.AspNetCore.Mvc;
using MotorcycleRentalSystem.DTO.Requests;
using MotorcycleRentalSystem.Api.Attributes;
using MotorcycleRentalSystem.Domain.Entities;
using MotorcycleRentalSystem.DTO.Responses;
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
    public async Task<IActionResult> Get(
        [FromServices] IReadRentOrdersUseCase useCase, [FromQuery] int offset, [FromQuery] int quantity
    )
    {
        var user = HttpContext.Items["User"] as User;
        return Ok(await useCase.Execute(user!.UserRole, user!.Id, offset, quantity));
    }

    [AdminAuth]
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(GetSelectedOrderResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(NotFoundResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById([FromServices] IReadRentOrdersUseCase useCase, [FromRoute] long id)
    {
        var path = HttpContext.Request.Path;
        GetSelectedOrderResponse? response = null;
        try
        {
            response = await useCase.Execute(id);
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
    [ProducesResponseType(typeof(CreatedResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(BadRequestResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RegisterNew([FromServices] ICreateRentOrdersUseCase useCase, [FromBody] NewRentOrderRequest request)
    {
        CreatedResponse? response = null;
        var path = HttpContext.Request.Path;
        var user = HttpContext.Items["User"] as User;
        try
        {
            response = await useCase.Execute(user!.Id, request);
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
    public async Task<IActionResult> UpdateOrder(
        [FromServices] IUpdateRentOrdersUseCase useCase, [FromBody] UpdateOrderRequest request, 
        [FromQuery] long id
    )
    {
        var path = HttpContext.Request.Path;
        var user = HttpContext.Items["User"] as User;
        try
        {
            await useCase.Execute(request, id, user!.Id);
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
