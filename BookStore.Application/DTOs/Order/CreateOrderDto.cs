namespace BookStore.Application.DTOs.Order
{
    public class CreateOrderDto
    {
        public string ShippingAddress { get; set; } = string.Empty;
        public List<CreateOrderItemDto> Items { get; set; } = new();
    }
}
