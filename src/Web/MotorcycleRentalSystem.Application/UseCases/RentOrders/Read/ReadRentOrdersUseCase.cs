using Microsoft.Extensions.Options;
using MotorcycleRentalSystem.Domain.Entities;
using MotorcycleRentalSystem.Domain.Enums;
using MotorcycleRentalSystem.Domain.Mappings.Out;
using MotorcycleRentalSystem.Domain.Options;
using MotorcycleRentalSystem.DTO.Responses;
using MotorcycleRentalSystem.Exceptions;
using MotorcycleRentalSystem.Domain.Repositories;

namespace MotorcycleRentalSystem.Application.UseCases.RentOrders.Read;

public class ReadRentOrdersUseCase(IRentOrderRepository rentOrderRepository, IOptions<AppSettings> appSettings) : IReadRentOrdersUseCase
{
    private readonly IRentOrderRepository _rentOrderRepository = rentOrderRepository;
    private readonly AppSettings _appSettings = appSettings.Value;
    private int QUANTITY_MAX => _appSettings.WideQueries?.RentOrdersMaxEntries ?? 100;
    
    public async Task<GetOrdersResponse> Execute(UserRoleEnum role, long userId, int offset, int quantity)
    {
        if (quantity == 0 || quantity > QUANTITY_MAX)
            quantity = QUANTITY_MAX;

        var vanillaResults = await _rentOrderRepository.GetAll();
        if (role == UserRoleEnum.RegularRole)
            vanillaResults = vanillaResults.Where(x => x.Deliveryman!.Id == userId);

        var resultsAfterSkip = vanillaResults.Skip(offset);
        var result = resultsAfterSkip.Take(quantity);
        var remaining = resultsAfterSkip.Count() - quantity;
        if (remaining < 0)
            remaining = 0;
        return new GetOrdersResponseMapper().Map(result, remaining, offset, quantity);
    }
    
    public async Task<GetSelectedOrderResponse> Execute(long id)
    {
        var order = await _rentOrderRepository.GetById(id);
        if (order is null)
            throw new EntityNotFoundException(
                "The requested order was not found.",
                typeof(RentOrder), id
            );

        return new GetSelectedOrderResponseMapper().Map("", order);
    }
}
