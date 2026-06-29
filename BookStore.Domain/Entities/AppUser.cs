using BookStore.Domain.Entities.Base;

namespace BookStore.Domain.Entities
{
    public class AppUser : BaseEntity
    {
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
