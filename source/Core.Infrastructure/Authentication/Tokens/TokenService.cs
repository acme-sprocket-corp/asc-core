using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Core.Application.Common.Clock;
using Microsoft.IdentityModel.Tokens;

namespace Core.Infrastructure.Authentication.Tokens
{
    public class TokenService : ITokenService
    {
        private readonly IClock _clock;
        private readonly TokenConfiguration _tokenConfiguration;

        public TokenService(IClock clock, TokenConfiguration tokenConfiguration)
        {
            _clock = clock;
            _tokenConfiguration = tokenConfiguration;
        }

        public string GenerateToken(IEnumerable<Claim> claims)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenConfiguration.Key));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                _tokenConfiguration.Issuer,
                _tokenConfiguration.Audience,
                claims,
                _clock.UtcNow(),
                _clock.UtcNow().AddMinutes(30),
                credentials);

            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }
    }
}
