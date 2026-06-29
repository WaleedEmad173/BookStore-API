using Microsoft.AspNetCore.Identity;

namespace BookStore.Domain.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
