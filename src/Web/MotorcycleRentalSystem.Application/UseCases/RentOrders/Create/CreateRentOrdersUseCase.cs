using MotorcycleRentalSystem.Domain.Entities;
using MotorcycleRentalSystem.Domain.Enums;
using MotorcycleRentalSystem.Domain.Requests;
using MotorcycleRentalSystem.Domain.Responses;
using MotorcycleRentalSystem.Domain.Services;
using MotorcycleRentalSystem.Exceptions;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;

namespace MotorcycleRentalSystem.Application.UseCases.RentOrders.Create;

public class CreateRentOrdersUseCase(
    IUserService userService, IMotorcycleService motorcycleService, 
    IRentQuoteService rentQuoteService, IRentOrderService rentOrderService) : ICreateRentOrdersUseCase
{
    private readonly IUserService _userService = userService;
    private readonly IMotorcycleService _motorcycleService = motorcycleService;
    private readonly IRentQuoteService _rentQuoteService = rentQuoteService;
    private readonly IRentOrderService _rentOrderService = rentOrderService;

    public CreatedResponse Execute(long id, NewRentOrderRequest request)
    {
        var cycle = _motorcycleService.GetById(request.MotorcycleId);
        var user = _userService.GetById(id) as DeliverymanUser;
        var begin = DateTime.Today.AddDays(1);
        Validate(user!, cycle, request);

        var plan = _rentQuoteService.EstimatePlan(request.PlanPeriod);
        RentOrder order = new()
        {
            Deliveryman = user,
            Motorcycle = _motorcycleService.GetById(request.MotorcycleId),
            RentPlan = plan,
            BeginAt = begin,
            EndAt = begin.AddDays((int)request.PlanPeriod - 1),
            TotalCost = plan.TotalCost
        };
        _rentOrderService.AddOrder(order);
        return new(order.Id);
    }

    private void Validate(DeliverymanUser user, Motorcycle? cycle, NewRentOrderRequest request)
    {
        if (user!.IsLastOrderActive)
            throw new BusinessLogicValidationFaultException(
                "Cannot proceed with the request: " +
                "The active user has a rent in progress. " +
                "The rent should be finished in order to proceed with a new rent order."
            );

        if (cycle is null)
            throw new FieldValidationFaultException(
                "The requested motorcycle was not found. Pick another one.",
                "MotorcycleId",
                request.MotorcycleId.ToString()
            );

        if (!Enum.GetValues<RentalPlanPeriodEnum>().Contains(request.PlanPeriod))
            throw new FieldValidationFaultException(
                "The requested plan period was not found. Pick another one.",
                "PlanPeriod",
                ((int)request.PlanPeriod).ToString()
            ); 
        
        if (cycle.IsLastOrderActive)
            throw new BusinessLogicValidationFaultException(
               "Cannot proceed with the request: " +
               "The requested vehicle is already in use. Pick another one." 
            );
    }
}
