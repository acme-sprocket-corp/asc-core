using Azure.Security.KeyVault.Secrets;

namespace Core.Infrastructure.Secrets
{
    public interface ISecretService
    {
        Task<Azure.Response<KeyVaultSecret>> GetSecretAsync(string secretKey);
    }
}
