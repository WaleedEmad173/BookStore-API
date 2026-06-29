namespace BookStore.Application.DTOs.Order
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string Status { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
        public string ShippingAddress { get; set; } = string.Empty;
        public int UserId { get; set; }
        public List<OrderItemDto> Items { get; set; } = new();
    }
}
