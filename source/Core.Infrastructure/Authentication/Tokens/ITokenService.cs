using System.Security.Claims;

namespace Core.Infrastructure.Authentication.Tokens
{
    public interface ITokenService
    {
        public string GenerateToken(IEnumerable<Claim> claims);
    }
}
