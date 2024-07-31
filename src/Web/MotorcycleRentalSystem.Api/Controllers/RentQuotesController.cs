using Microsoft.AspNetCore.Mvc;
using MotorcycleRentalSystem.Domain.Services;
using MotorcycleRentalSystem.DTO.Responses;
using MotorcycleRentalSystem.Domain.Enums;
using System.IO;
using MotorcycleRentalSystem.Application.UseCases.RentQuotes.Read;
using MotorcycleRentalSystem.Exceptions;
using System.Numerics;

namespace MotorcycleRentalSystem.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class RentQuotesController : ControllerBase
{
    [HttpGet("plans")]
    [ProducesResponseType(typeof(GetPlansResponse), StatusCodes.Status200OK)]
    public IActionResult Get([FromServices] IReadRentQuotesUseCase useCase)
    {
        return Ok(useCase.Execute());
    }
    
    [HttpGet("calculatePlan/{plan}")]
    [ProducesResponseType(typeof(CalculatePlanResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(NotFoundResponse), StatusCodes.Status404NotFound)]
    public IActionResult CalculatePlan([FromServices] IReadRentQuotesUseCase useCase, [FromRoute] RentalPlanPeriodEnum plan)
    {
        try
        {
            return Ok(useCase.Execute(plan));
        }
        catch (EntityNotFoundException e)
        {
            return NotFound(new NotFoundResponse(e.Message, HttpContext.Request.Path));
        }
    }

    [HttpGet("calculateFine")]
    [ProducesResponseType(typeof(CalculateFineResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(NotFoundResponse), StatusCodes.Status404NotFound)]
    public IActionResult CalculateFine([FromServices] IReadRentQuotesUseCase useCase, [FromQuery] RentalPlanPeriodEnum planPeriod, [FromQuery] DateTime estimated, [FromQuery] DateTime actually)
    {
        try
        {
            return Ok(useCase.Execute(planPeriod, estimated, actually));
        }
        catch (EntityNotFoundException e)
        {
            return NotFound(new NotFoundResponse(e.Message, HttpContext.Request.Path));
        }
    }
}
