using MotorcycleRentalSystem.DTO.ResponseObjects;

namespace MotorcycleRentalSystem.DTO.Responses;
public class GetSelectedOrderResponse : ResponseBase
{
    public string? Path { get; set; }
    public RentOrderDTO? RentOrder { get; set; }
}
