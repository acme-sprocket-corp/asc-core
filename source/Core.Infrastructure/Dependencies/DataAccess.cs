using Azure.Security.KeyVault.Secrets;
using Core.Infrastructure.DataAccess.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Infrastructure.Dependencies
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
