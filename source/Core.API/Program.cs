// <copyright file="Program.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System.Reflection;
using Core.Infrastructure.Authentication.Tokens;
using Core.Infrastructure.Dependencies;
using MediatorBuddy.AspNet.Registration;
using Serilog;

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

            // var secretFactory = new SecretClientFactory(builder.Configuration);
            // var connectionString = await secretFactory.GetConnectionString();
            // var tokenConfiguration = await secretFactory.GetTokenConfiguration();
            var tokenConfiguration = new TokenConfiguration(
                builder.Configuration["KeyVault:Secrets:Security:Audience"] ?? string.Empty,
                builder.Configuration["KeyVault:Secrets:Security:Issuer"] ?? string.Empty,
                builder.Configuration["KeyVault:Secrets:Security:Key"] ?? string.Empty);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwagger();
            builder.Services.AddCoreApplication();
            builder.Services.AddJwtAuthorization(tokenConfiguration);
            builder.Services.AddDataAccess(builder.Configuration.GetConnectionString("Database") ?? string.Empty);
            builder.Services.AddMediatorBuddy(configuration => configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            builder.Services.AddSerilog(configuration => configuration.WriteTo.Console());

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