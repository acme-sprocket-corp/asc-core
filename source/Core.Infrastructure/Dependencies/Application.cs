using System.Reflection;
using Core.Application.Customers.Common;
using Core.Domain.Common.Clock;
using Core.Infrastructure.Authentication.Tokens;
using Core.Infrastructure.Clock;
using Core.Infrastructure.DataAccess.Customers;
using Core.Infrastructure.Secrets;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Infrastructure.Dependencies
{
    public static class Application
    {
        public static void AddCoreApplication(this IServiceCollection services)
        {
            services.AddTransient<ITokenService, TokenService>();

            services.AddSingleton<IClock, SystemClock>();

            services.AddTransient<ISecretService, SecretService>();

            services.AddMediatR(configuration => configuration.RegisterServicesFromAssemblies(
                Assembly.Load("Core.Application"),
                Assembly.Load("Core.Infrastructure")));

            // Customers
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<CustomerFactory>();
        }
    }
}
