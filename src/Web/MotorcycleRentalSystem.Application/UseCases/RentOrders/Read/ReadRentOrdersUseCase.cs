using Microsoft.Extensions.Options;
using MotorcycleRentalSystem.Domain.Entities;
using MotorcycleRentalSystem.Domain.Enums;
using MotorcycleRentalSystem.Domain.Options;
using MotorcycleRentalSystem.Domain.Responses;
using MotorcycleRentalSystem.Domain.Services;
using MotorcycleRentalSystem.Exceptions;

namespace MotorcycleRentalSystem.Application.UseCases.RentOrders.Read;

public class ReadRentOrdersUseCase(IRentOrderService rentOrderService, IOptions<AppSettings> appSettings) : IReadRentOrdersUseCase
{
    private readonly IRentOrderService _rentOrderService = rentOrderService;
    private readonly AppSettings _appSettings = appSettings.Value;
    private int QUANTITY_MAX => _appSettings.WideQueries?.RentoOrdersMaxEntries ?? 100;
    
    public GetOrdersResponse Execute(UserRoleEnum role, long userId, int offset, int quantity)
    {
        if (quantity == 0 || quantity > QUANTITY_MAX)
            quantity = QUANTITY_MAX;

        var vanillaResults = _rentOrderService.GetAll();
        if (role == UserRoleEnum.RegularRole)
            vanillaResults = vanillaResults.Where(x => x.Deliveryman!.Id == userId);

        var resultsAfterSkip = vanillaResults.Skip(offset);
        var result = resultsAfterSkip.Take(quantity);
        var remaining = resultsAfterSkip.Count() - quantity;
        if (remaining < 0)
            remaining = 0;
        return new (result, remaining, offset, quantity);
    }
    
    public GetSelectedOrderResponse Execute(long id)
    {
        var order = _rentOrderService.GetById(id);
        if (order is null)
            throw new EntityNotFoundException(
                "The requested order was not found.",
                typeof(RentOrder), id
            );

        return new ("", order);
    }
}
