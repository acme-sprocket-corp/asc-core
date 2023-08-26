using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Core.Infrastructure.Authentication.Tokens;
using Microsoft.Extensions.Configuration;

namespace Core.Infrastructure.Secrets
{
    public class SecretClientFactory
    {
        private readonly IConfiguration _configuration;
        private readonly SecretClient _secretClient;

        public SecretClientFactory(IConfiguration configuration)
        {
            _configuration = configuration;

            var keyVaultName = configuration["KeyVault:Name"];

            if (keyVaultName == null)
            {
                throw new ArgumentNullException(nameof(keyVaultName), "KeyVault name must not be null.");
            }

            _secretClient = new SecretClient(new Uri(keyVaultName), new DefaultAzureCredential());
        }

        public async Task<string> GetConnectionString()
        {
            var secret = await _secretClient.GetSecretAsync(_configuration["KeyVault:Secrets:Database"]);

            return secret.Value.Value;
        }

        public async Task<TokenConfiguration> GetTokenConfiguration()
        {
            var audienceResponse = await _secretClient.GetSecretAsync(_configuration["KeyVault:Secrets:Security:Audience"]);
            var issuerResponse = await _secretClient.GetSecretAsync(_configuration["KeyVault:Secrets:Security:Issuer"]);
            var keyResponse = await _secretClient.GetSecretAsync(_configuration["KeyVault:Secrets:Security:Key"]);

            return new TokenConfiguration();
        }
    }
}
