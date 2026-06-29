namespace BookStore.Application.DTOs.OrderItem
{
    public class CreateOrderItemDto
    {
        public int BookId { get; set; }
        public int Quantity { get; set; }
    }
}
