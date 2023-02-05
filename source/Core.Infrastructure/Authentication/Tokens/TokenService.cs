using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Core.Application.Common.Clock;
using Core.Infrastructure.Secrets;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Core.Infrastructure.Authentication.Tokens
{
    public class TokenService : ITokenService
    {
        private readonly IClock _clock;
        private readonly IConfiguration _configuration;
        private readonly ISecretService _secretService;

        public TokenService(IConfiguration configuration, IClock clock, ISecretService secretService)
        {
            _clock = clock;
            _secretService = secretService;
            _configuration = configuration;
        }

        public async Task<string> GenerateToken(IEnumerable<Claim> claims)
        {
            var jwtAudience = _configuration["KeyVault:Secrets:Security:Audience"];
            var jwtIssuer = _configuration["KeyVault:Secrets:Security:Issuer"];
            var jwtKey = _configuration["KeyVault:Secrets:Security:Key"];

            if (jwtAudience == null)
            {
                throw new ArgumentNullException(nameof(jwtAudience), "Audience must not be null.");
            }

            if (jwtIssuer == null)
            {
                throw new ArgumentNullException(nameof(jwtKey), "Issuer must not be null.");
            }

            if (jwtKey == null)
            {
                throw new ArgumentNullException(nameof(jwtKey), "Key must not be null.");
            }

            var audienceResponse = await _secretService.GetSecretAsync(jwtAudience);
            var issuerResponse = await _secretService.GetSecretAsync(jwtIssuer);
            var keyResponse = await _secretService.GetSecretAsync(jwtKey);

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyResponse.Value.Value));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuerResponse.Value.Value,
                audienceResponse.Value.Value,
                claims,
                _clock.UtcNow(),
                _clock.UtcNow().AddMinutes(30),
                credentials);

            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }
    }
}
