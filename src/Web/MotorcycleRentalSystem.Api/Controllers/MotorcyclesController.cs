using Microsoft.AspNetCore.Mvc;
using MotorcycleRentalSystem.DTO.Requests;
using MotorcycleRentalSystem.Exceptions;
using MotorcycleRentalSystem.Api.Attributes;
using MotorcycleRentalSystem.Application.UseCases.Motorcycles.Create;
using MotorcycleRentalSystem.Application.UseCases.Motorcycles.Delete;
using MotorcycleRentalSystem.Application.UseCases.Motorcycles.Read;
using MotorcycleRentalSystem.Application.UseCases.Motorcycles.Update;
using MotorcycleRentalSystem.Domain.Entities;
using MotorcycleRentalSystem.Domain.Enums;
using MotorcycleRentalSystem.DTO.Responses;

namespace MotorcycleRentalSystem.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class MotorcyclesController : ControllerBase
{
    [Authorize]
    [HttpGet]
    [ProducesResponseType(typeof(GetMotorcyclesResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get(
        [FromServices] IReadMotorcyclesUseCase useCase,
        [FromQuery] int offset = 0, [FromQuery] int quantity = 0,
        [FromQuery] AvailabilityFilterEnum availabilityFilter = AvailabilityFilterEnum.None
    )
    {
        var user = HttpContext.Items["User"] as User;
        return Ok(await useCase.Execute(user!.UserRole, offset, quantity, availabilityFilter));
    }

    [AdminAuth]
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(GetSelectedMotorcycleResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(NotFoundResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById([FromServices] IReadMotorcyclesUseCase useCase, [FromRoute] long id)
    {
        var path = HttpContext.Request.Path;
        GetSelectedMotorcycleResponse? response = null;
        try
        {
            response = await useCase.Execute(id);
        }
        catch (EntityNotFoundException e)
        {
            return NotFound(new NotFoundResponse(e.Message, path));
        }
        response!.Path = path;
        return Ok(response);
    }
    
    [AdminAuth]
    [HttpGet("byLicensePlate/{licensePlate}")]
    [ProducesResponseType(typeof(GetSelectedMotorcycleResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(NotFoundResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByLicensePlate([FromServices] IReadMotorcyclesUseCase useCase, [FromRoute] string licensePlate)
    {
        var path = HttpContext.Request.Path;
        GetSelectedMotorcycleResponse? response = null;
        try
        {
            response = await useCase.Execute(licensePlate);
        }
        catch (EntityNotFoundException e)
        {
            return NotFound(new NotFoundResponse(e.Message, path));
        }
        response!.Path = path;
        return Ok(response);
    }

    [AdminAuth]
    [HttpPost]
    [ProducesResponseType(typeof(CreatedResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(BadRequestResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RegisterNew([FromServices] ICreateMotorcyclesUseCase useCase, [FromBody] NewMotorcycleRequest request)
    {
        var path = HttpContext.Request.Path;
        long createdId;
        try
        {
            createdId = await useCase.Execute(request);
        }
        catch (FieldValidationFaultException e)
        {
            return BadRequest(new BadRequestResponse(e.Message, e.Field, e.Value?.ToString()));
        }
        return Created(path + "/" + createdId.ToString(), new CreatedResponse(createdId));
    }

    [AdminAuth]
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(NotFoundResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(BadRequestResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateLicensePlate([FromServices] IUpdateMotorcyclesUseCase useCase, [FromBody] UpdateLicensePlateRequest request, [FromRoute] long id)
    {
        try
        {
            await useCase.Execute(request, id);
        }
        catch (EntityNotFoundException e)
        {
            return NotFound(new NotFoundResponse(e.Message, HttpContext.Request.Path));
        }
        catch (FieldValidationFaultException e)
        {
            return BadRequest(new BadRequestResponse(e.Message, e.Field, e.Value?.ToString()));
        }
        return Ok();
    }

    [AdminAuth]
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(NotFoundResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(BadRequestResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Remove([FromServices] IDeleteMotorcyclesUseCase useCase, [FromRoute] long id)
    {
        try
        {
            await useCase.Execute(id);
        }
        catch (EntityNotFoundException e)
        {
            return NotFound(new NotFoundResponse(e.Message, HttpContext.Request.Path));
        }
        catch (BusinessLogicValidationFaultException e)
        {
            return BadRequest(new BadRequestResponse(e.Message));
        }
        return Ok();
    }
}
