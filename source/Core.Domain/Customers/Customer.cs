using Microsoft.AspNetCore.Identity;

namespace Core.Domain.Customers
{
    public sealed class Customer : IdentityUser<Guid>
    {
        public Customer(string username, string email)
            : base(username)
        {
            Email = email;
        }

        private Customer()
        {
        }
    }
}
