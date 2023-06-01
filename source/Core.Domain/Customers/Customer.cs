using Core.Domain.Common.Clock;
using Microsoft.AspNetCore.Identity;

namespace Core.Domain.Customers
{
    public sealed class Customer : IdentityUser<Guid>
    {
        public Customer(string userName, string email)
            : base(userName)
        {
            Email = email;
        }

        private Customer()
        {
        }

        public string? RefreshToken { get; private set; }

        public DateTime RefreshTokenExpiration { get; private set; }

        public override string UserName
        {
            get => base.UserName ?? throw new NullReferenceException();
        }

        public override string Email
        {
            get => base.Email ?? throw new NullReferenceException();
        }

        public void UpdateRefreshToken(string refreshToken, IClock clock)
        {
            const int clockSkew = 15;

            RefreshToken = refreshToken;
            RefreshTokenExpiration = clock.UtcNow().AddMinutes(clockSkew);
        }

        public void ResetRefreshToken(IClock clock)
        {
            RefreshToken = null;
            RefreshTokenExpiration = clock.UtcNow();
        }
    }
}
