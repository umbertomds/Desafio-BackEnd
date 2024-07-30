using MotorcycleRentalSystem.Domain.Entities;

namespace MotorcycleRentalSystem.Domain.Responses;
public class GetSelectedOrderResponse(string path, RentOrder rentOrder) : ResponseBase
{
    public string Path { get; set; } = path;
    public RentOrder RentOrder { get; set; } = rentOrder;
}
