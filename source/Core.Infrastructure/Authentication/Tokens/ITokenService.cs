using System.Security.Claims;

namespace Core.Infrastructure.Authentication.Tokens
{
    public interface ITokenService
    {
        public string GenerateAccessToken(IEnumerable<Claim> claims);

        public string GenerateRefreshToken();
    }
}
