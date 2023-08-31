using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Core.Domain.Common.Clock;
using Core.Infrastructure.Authentication.Tokens;
using Moq;

namespace Core.Tests.Unit.Infrastructure.Authentication.Tokens
{
    [TestClass]
    public class TokenServiceTests
    {
        private readonly Mock<IClock> _clock;

        public TokenServiceTests()
        {
            _clock = new Mock<IClock>();
        }

        [TestMethod]
        public void GenerateToken_HasCorrectProperties()
        {
            const string audience = "tokenAudience";
            const string issuer = "tokenIssuer";
            const string key = "thisIsMyTestTokenKey12837superSecret81727!";

            var tokenConfiguration = new TokenConfiguration(audience, issuer, key);

            var validStart = new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var validTo = validStart.AddMinutes(30);
            _clock.Setup(clock => clock.UtcNow()).Returns(validStart);

            var service = new TokenService(_clock.Object, tokenConfiguration);

            var tokenResult = service.GenerateAccessToken(Enumerable.Empty<Claim>());

            var decoded = new JwtSecurityTokenHandler().ReadJwtToken(tokenResult);

            Assert.IsTrue(decoded.Audiences.Contains(audience));
            Assert.AreEqual(issuer, decoded.Issuer);
            Assert.AreEqual(4, decoded.Claims.Count());
            Assert.AreEqual(validStart, decoded.ValidFrom);
            Assert.AreEqual(validTo, decoded.ValidTo);
        }
    }
}
