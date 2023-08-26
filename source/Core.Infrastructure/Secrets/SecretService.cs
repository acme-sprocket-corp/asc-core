using Azure.Security.KeyVault.Secrets;
using Microsoft.Extensions.Configuration;

namespace Core.Infrastructure.Secrets
{
    public class SecretService : ISecretService
    {
        private readonly SecretClient _secretClient;

        public SecretService(IConfiguration configuration)
        {
            _secretClient = SecretClientFactory.GetConnectionString(configuration);
        }

        public async Task<Azure.Response<KeyVaultSecret>> GetSecretAsync(string secretKey)
        {
            return await _secretClient.GetSecretAsync(secretKey);
        }
    }
}
