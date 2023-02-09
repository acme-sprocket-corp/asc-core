using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Azure;
using Azure.Security.KeyVault.Secrets;
using Core.Application.Common.Clock;
using Core.Infrastructure.Authentication.Tokens;
using Core.Infrastructure.Secrets;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Moq;

namespace Core.Tests.Unit.Infrastructure.Authentication.Tokens
{
    [TestClass]
    public class TokenServiceTests
    {
        private readonly Mock<IClock> _clock;
        private readonly Mock<IConfiguration> _configuration;
        private readonly Mock<ISecretService> _secretService;

        public TokenServiceTests()
        {
            _clock = new Mock<IClock>();
            _configuration = new Mock<IConfiguration>();
            _secretService = new Mock<ISecretService>();
        }

        [TestMethod]
        public void GenerateToken_NullAudience_ThrowsException()
        {
            _configuration.Setup(configuration => configuration["KeyVault:Secrets:Security:Audience"]).Returns(() => null);

            var service = new TokenService(_clock.Object, _configuration.Object, _secretService.Object);

            Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await service.GenerateToken(Enumerable.Empty<Claim>()));
        }

        [TestMethod]
        public void GenerateToken_NullIssuer_ThrowsException()
        {
            _configuration.Setup(configuration => configuration["KeyVault:Secrets:Security:Issuer"]).Returns(() => null);

            var service = new TokenService(_clock.Object, _configuration.Object, _secretService.Object);

            Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await service.GenerateToken(Enumerable.Empty<Claim>()));
        }

        [TestMethod]
        public void GenerateToken_NullKey_ThrowsException()
        {
            _configuration.Setup(configuration => configuration["KeyVault:Secrets:Security:Key"]).Returns(() => null);

            var service = new TokenService(_clock.Object, _configuration.Object, _secretService.Object);

            Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await service.GenerateToken(Enumerable.Empty<Claim>()));
        }

        [TestMethod]
        public async Task GenerateToken_HasCorrectProperties()
        {
            const string audience = "tokenAudience";
            const string issuer = "tokenIssuer";
            const string key = "thisIsMyTestTokenKey";

            _configuration.Setup(configuration => configuration["KeyVault:Secrets:Security:Audience"]).Returns(audience);
            _configuration.Setup(configuration => configuration["KeyVault:Secrets:Security:Issuer"]).Returns(issuer);
            _configuration.Setup(configuration => configuration["KeyVault:Secrets:Security:Key"]).Returns(key);

            _secretService.Setup(service => service.GetSecretAsync(audience))
                .Returns(Task.FromResult(Response.FromValue(new KeyVaultSecret(audience, audience), Mock.Of<Response>())));

            _secretService.Setup(service => service.GetSecretAsync(issuer))
                .Returns(Task.FromResult(Response.FromValue(new KeyVaultSecret(issuer, issuer), Mock.Of<Response>())));

            _secretService.Setup(service => service.GetSecretAsync(key))
                .Returns(Task.FromResult(Response.FromValue(new KeyVaultSecret(key, key), Mock.Of<Response>())));

            var validStart = new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var validTo = validStart.AddMinutes(30);
            _clock.Setup(clock => clock.UtcNow()).Returns(validStart);

            var service = new TokenService(_clock.Object, _configuration.Object, _secretService.Object);

            var tokenResult = await service.GenerateToken(Enumerable.Empty<Claim>());

            var decoded = new JwtSecurityTokenHandler().ReadJwtToken(tokenResult);

            Assert.IsTrue(decoded.Audiences.Contains(audience));
            Assert.AreEqual(issuer, decoded.Issuer);
            Assert.AreEqual(4, decoded.Claims.Count());
            Assert.AreEqual(validStart, decoded.ValidFrom);
            Assert.AreEqual(validTo, decoded.ValidTo);
        }
    }
}
