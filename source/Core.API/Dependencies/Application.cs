using System.Reflection;
using Core.Application.Common.Clock;
using Core.Application.Customers.Common;
using Core.Infrastructure.Authentication.Tokens;
using Core.Infrastructure.Clock;
using Core.Infrastructure.DataAccess.Customers;
using Core.Infrastructure.Secrets;

namespace Core.API.Dependencies
{
    public static class Application
    {
        public static void AddCoreApplication(this IServiceCollection services)
        {
            services.AddTransient<ITokenService, TokenService>();

            services.AddSingleton<IClock, SystemClock>();

            services.AddTransient<ISecretService, SecretService>();

            services.AddMediatR(x => x.RegisterServicesFromAssemblies(Assembly.Load("Core.Application")));

            // Customers
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<CustomerFactory>();
        }
    }
}
