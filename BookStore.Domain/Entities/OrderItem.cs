using BookStore.Domain.Entities.Base;

namespace BookStore.Domain.Entities
{
    public class OrderItem : BaseEntity
    {
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int BookId { get; set; }
        public int OrderId { get; set; }
        public Book Book { get; set; } = null!;
        public Order Order { get; set; } = null!;
    }
}
