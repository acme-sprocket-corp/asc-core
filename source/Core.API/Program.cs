using Core.Infrastructure.Dependencies;
using Core.Infrastructure.Secrets;

namespace Core.API
{
    /// <summary>
    /// Entry class for the application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point for the Web application.
        /// </summary>
        /// <param name="args">Command line arguments.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var secretFactory = new SecretClientFactory(builder.Configuration);
            var connectionString = await secretFactory.GetConnectionString();
            var tokenConfiguration = await secretFactory.GetTokenConfiguration();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwagger();
            builder.Services.AddCoreApplication();
            builder.Services.AddJwtAuthorization(tokenConfiguration);
            builder.Services.AddDataAccess(connectionString);

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseCors(policyBuilder => policyBuilder.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            await app.RunAsync();
        }
    }
}