using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace Core.API.Dependencies
{
    public static class DataAccess
    {
        public static async Task AddDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            var keyVaultName = configuration["KeyVault:Name"];

            if (keyVaultName == null)
            {
                throw new ArgumentNullException(nameof(keyVaultName));
            }

            var client = new SecretClient(new Uri(keyVaultName), new DefaultAzureCredential());

            var secretResponse = await client.GetSecretAsync(configuration["KeyVault:Secrets:Database"]);
        }
    }
}
