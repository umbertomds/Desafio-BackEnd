using MotorcycleRentalSystem.DTO.Requests;
using MotorcycleRentalSystem.Domain.Entities;
using MotorcycleRentalSystem.Domain.Enums;
using MotorcycleRentalSystem.Domain.Mappings.In;
using MotorcycleRentalSystem.DTO.Responses;
using MotorcycleRentalSystem.Domain.Services;
using MotorcycleRentalSystem.Exceptions;
using MotorcycleRentalSystem.Domain.Repositories;
using MotorcycleRentalSystem.Domain.Helpers;

namespace MotorcycleRentalSystem.Application.UseCases.RentOrders.Create;

public class CreateRentOrdersUseCase(
    IUserRepository userRepository, IMotorcycleRepository motorcycleRepository, 
    IRentQuoteService rentQuoteService, IRentOrderRepository rentOrderRepository) : ICreateRentOrdersUseCase
{
    private readonly ToRentalPlanPeriodEnum rentalPlanPeriodEnum = new();
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IMotorcycleRepository _motorcycleRepository = motorcycleRepository;
    private readonly IRentQuoteService _rentQuoteService = rentQuoteService;
    private readonly IRentOrderRepository _rentOrderRepository = rentOrderRepository;

    public async Task<CreatedResponse> Execute(long id, NewRentOrderRequest request)
    {
        var cycle = await _motorcycleRepository.GetById(request.MotorcycleId);
        var user = await _userRepository.GetById(id) as DeliverymanUser;
        var begin = DateUtcHelper.Today().AddDays(1);
        Validate(user!, cycle, request);

        var plan = _rentQuoteService.EstimatePlan(rentalPlanPeriodEnum.Convert(request.PlanPeriod));
        RentOrder order = new()
        {
            Deliveryman = user,
            Motorcycle = await _motorcycleRepository.GetById(request.MotorcycleId),
            RentPlan = plan,
            BeginAt = begin,
            EstimatedEndAt = begin.AddDays((int)request.PlanPeriod - 1),
            TotalCost = plan.TotalCost,
        };
        await _rentOrderRepository.Add(order);
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

        LicenseTypeEnum[] allowedLicenses = [
            LicenseTypeEnum.TypeA,
            LicenseTypeEnum.TypeAB
        ];
        if (!allowedLicenses.Contains(user!.DriverLicense.Type))
            throw new BusinessLogicValidationFaultException(
                "Cannot proceed with the request: " +
                "The active user's driver license type doesn't allow him to " +
                "rent motorcycles."
            );

        if (cycle is null)
            throw new FieldValidationFaultException(
                "The requested motorcycle was not found. Pick another one.",
                "MotorcycleId",
                request.MotorcycleId.ToString()
            );

        if (!Enum.GetValues<RentalPlanPeriodEnum>().Contains(
            rentalPlanPeriodEnum.Convert(request.PlanPeriod))
        )
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
