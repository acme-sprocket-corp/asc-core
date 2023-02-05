using Azure.Security.KeyVault.Secrets;
using Core.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Core.API.Dependencies
{
    public static class DataAccess
    {
        public static async Task AddDataAccess(this IServiceCollection services, IConfiguration configuration, SecretClient client)
        {
            var secretResponse = await client.GetSecretAsync(configuration["KeyVault:Secrets:Database"]);

            services.AddDbContext<ApplicationContext>(builder => builder.UseSqlServer(secretResponse.Value.Value));
        }
    }
}
