using Microsoft.AspNetCore.Identity;

namespace BookStore.Domain.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
