using Core.Application.Common.Clock;
using Core.Infrastructure.Authentication.Tokens;
using Core.Infrastructure.Clock;
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
        }
    }
}
