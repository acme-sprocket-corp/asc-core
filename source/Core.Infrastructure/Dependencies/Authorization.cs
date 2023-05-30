using System.Text;
using Azure.Security.KeyVault.Secrets;
using Core.Domain.Customers;
using Core.Infrastructure.Authentication.Tokens;
using Core.Infrastructure.DataAccess.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Core.Infrastructure.Dependencies
{
    public static class Authorization
    {
        public static async Task AddJwtAuthorization(this IServiceCollection services, IConfiguration configuration, SecretClient client)
        {
            services.AddIdentity<Customer, IdentityRole<Guid>>()
                .AddEntityFrameworkStores<ApplicationContext>()
                .AddDefaultTokenProviders();

            services.AddAuthorization();

            var audienceResponse = await client.GetSecretAsync(configuration["KeyVault:Secrets:Security:Audience"]);
            var issuerResponse = await client.GetSecretAsync(configuration["KeyVault:Secrets:Security:Issuer"]);
            var keyResponse = await client.GetSecretAsync(configuration["KeyVault:Secrets:Security:Key"]);

            services.AddSingleton(_ => new TokenConfiguration(audienceResponse.Value.Value, issuerResponse.Value.Value, keyResponse.Value.Value));

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidAudience = audienceResponse.Value.Value,
                    ValidIssuer = issuerResponse.Value.Value,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyResponse.Value.Value)),
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                };
            });
        }
    }
}
