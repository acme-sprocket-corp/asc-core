using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Core.Infrastructure.Authentication.Tokens;
using Microsoft.Extensions.Configuration;

namespace Core.Infrastructure.Secrets
{
    /// <summary>
    /// Factory class to retrieve secret values.
    /// </summary>
    public class SecretClientFactory
    {
        private readonly IConfiguration _configuration;
        private readonly SecretClient _secretClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="SecretClientFactory"/> class.
        /// </summary>
        /// <param name="configuration">An instance of the <see cref="IConfiguration"/> interface.</param>
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

        /// <summary>
        /// Retrieves the persistence connection string from secrets.
        /// </summary>
        /// <returns>A <see cref="Task"/> of type string representing the asynchronous operation.</returns>
        public async Task<string> GetConnectionString()
        {
            var secret = await _secretClient.GetSecretAsync(_configuration["KeyVault:Secrets:Database"]);

            return secret.Value.Value;
        }

        /// <summary>
        /// Retrieves the token related properties from secrets.
        /// </summary>
        /// <returns>A <see cref="Task"/> of type <see cref="TokenConfiguration"/> representing the asynchronous operation.</returns>
        /// <exception cref="NullReferenceException">Thrown when values are not found.</exception>
        public async Task<TokenConfiguration> GetTokenConfiguration()
        {
            var audienceResponse = await _secretClient.GetSecretAsync(_configuration["KeyVault:Secrets:Security:Audience"]);
            var issuerResponse = await _secretClient.GetSecretAsync(_configuration["KeyVault:Secrets:Security:Issuer"]);
            var keyResponse = await _secretClient.GetSecretAsync(_configuration["KeyVault:Secrets:Security:Key"]);

            var audience = audienceResponse.Value ?? throw new NullReferenceException("Audience was null.");
            var issuer = issuerResponse.Value ?? throw new NullReferenceException("Issuer was null.");
            var key = keyResponse.Value ?? throw new NullReferenceException("Key was null.");

            return new TokenConfiguration(audience.Value, issuer.Value, key.Value);
        }
    }
}
