using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.Extensions.Configuration;

namespace Core.Infrastructure.Secrets
{
    public class SecretClientFactory
    {
        public static SecretClient GetSecretClient(IConfiguration configuration)
        {
            var keyVaultName = configuration["KeyVault:Name"];

            if (keyVaultName == null)
            {
                throw new ArgumentNullException(nameof(keyVaultName), "KeyVault name must not be null.");
            }

            return new SecretClient(new Uri(keyVaultName), new DefaultAzureCredential());
        }
    }
}
