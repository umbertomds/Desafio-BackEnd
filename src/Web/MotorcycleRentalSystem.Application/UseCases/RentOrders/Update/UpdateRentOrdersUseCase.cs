using MotorcycleRentalSystem.DTO.Requests;
using MotorcycleRentalSystem.Domain.Entities;
using MotorcycleRentalSystem.Domain.Enums;
using MotorcycleRentalSystem.Domain.Services;
using MotorcycleRentalSystem.Exceptions;
using MotorcycleRentalSystem.Domain.Repositories;

namespace MotorcycleRentalSystem.Application.UseCases.RentOrders.Update;

public class UpdateRentOrdersUseCase(IRentQuoteService rentQuoteService, IRentOrderRepository rentOrderRepository) : IUpdateRentOrdersUseCase
{
    private readonly IRentQuoteService _rentQuoteService = rentQuoteService;
    private readonly IRentOrderRepository _rentOrderRepository = rentOrderRepository;
    
    public async Task Execute(UpdateOrderRequest request, long id, long userId)
    {
        var order = await _rentOrderRepository.GetById(id);
        Validate(id, userId, order, request);

        var determinedFine = _rentQuoteService.EstimatePlanFine(order!.RentPlan.PlanPeriod, order!.EstimatedEndAt, request.EndAtDate);
        order.EndAt = request.EndAtDate;
        order.FinePlan = determinedFine;
        order.TotalCost = order.RentPlan.TotalCost + order.FinePlan.Total;
    }

    private void Validate(long id, long userId, RentOrder? order, UpdateOrderRequest request)
    {
        if (order is null || order.Deliveryman!.Id != userId)
            throw new EntityNotFoundException(
                "The requested order was not found.",
                typeof(RentOrder), id
            );

        if (order.State == RentOrderStateEnum.Finished)
            throw new BusinessLogicValidationFaultException(
                "Cannot proceed with the request: " +
                "The requested order no longer accepts modifications."
            );

        if (request.EndAtDate <= order.BeginAt)
            throw new FieldValidationFaultException(
                "Cannot proceed with the request: " +
                "The end date was given is earlier or equal to the beginning date.",
                "EndAtDate", request.EndAtDate.ToShortDateString()
            );
    }
}
