using Core.API.Dependencies;

namespace Core.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var secretClient = SecretClientFactory.GetSecretClient(builder.Configuration);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwagger();
            await builder.Services.AddJwtAuthorization(builder.Configuration, secretClient);
            await builder.Services.AddDataAccess(builder.Configuration, secretClient);

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(policyBuilder => policyBuilder.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

            app.UseHttpsRedirection();

            app.MapControllers();

            await app.RunAsync();
        }
    }
}