using BookStore.Domain.Entities.Base;
using BookStore.Domain.Enums;

namespace BookStore.Domain.Entities
{
    public class Order : BaseEntity
    {
        public enStatus Status { get; set; } = enStatus.Pending;
        public decimal TotalAmount { get; set; }
        public string ShippingAddress { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    }
}
