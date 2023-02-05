using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace Core.API.Dependencies
{
    public class SecretClientFactory
    {
        public static SecretClient GetSecretClient(IConfiguration configuration)
        {
            var keyVaultName = configuration["KeyVault:Name"];

            if (keyVaultName == null)
            {
                throw new ArgumentNullException(nameof(keyVaultName));
            }

            return new SecretClient(new Uri(keyVaultName), new DefaultAzureCredential());
        }
    }
}
