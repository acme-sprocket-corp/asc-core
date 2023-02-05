using System.Security.Claims;

namespace Core.Infrastructure.Authentication.Tokens
{
    public interface ITokenService
    {
        public Task<string> GenerateToken(IEnumerable<Claim> claims);
    }
}
