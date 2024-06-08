// <copyright file="Application.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System.Reflection;
using Core.Application.Customers.Common;
using Core.Domain.Common.Clock;
using Core.Infrastructure.Authentication.Tokens;
using Core.Infrastructure.Clock;
using Core.Infrastructure.DataAccess.Customers;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Infrastructure.Dependencies
{
    /// <summary>
    /// Adds all dependencies for the application layer.
    /// </summary>
    public static class Application
    {
        /// <summary>
        /// Adds dependencies for the application layer.
        /// </summary>
        /// <param name="services">The service container.</param>
        public static void AddCoreApplication(this IServiceCollection services)
        {
            services.AddTransient<ITokenService, TokenService>();

            services.AddSingleton<IClock, SystemClock>();

            services.AddMediatR(configuration => configuration.RegisterServicesFromAssemblies(
                Assembly.Load("Core.Application"),
                Assembly.Load("Core.Infrastructure")));

            // Customers
            services.AddTransient<ICustomerRepository, CustomerRepository>();
        }
    }
}
