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

        public override string UserName
        {
            get => base.UserName ?? throw new NullReferenceException();
        }

        public override string Email
        {
            get => base.Email ?? throw new NullReferenceException();
        }
    }
}
