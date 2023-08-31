using Core.Infrastructure.DataAccess.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Infrastructure.Dependencies
{
    /// <summary>
    /// Adds all persistence based dependencies.
    /// </summary>
    public static class DataAccess
    {
        /// <summary>
        /// Adds any persistence dependencies.
        /// </summary>
        /// <param name="services">An instance of <see cref="IServiceCollection"/>.</param>
        /// <param name="connectionString">The persistence connection string.</param>
        public static void AddDataAccess(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationContext>(builder => builder.UseSqlServer(connectionString));
        }
    }
}
