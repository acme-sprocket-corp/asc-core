﻿using Core.Domain.Customers;
using Core.Infrastructure.DataAccess.Common;
using Core.Infrastructure.Dependencies;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Tests.Integration.Common
{
    public static class DependencyHelpers
    {
        private static IServiceProvider? _provider;

        public static IRequestHandler<TRequest, TResponse> GetHandler<TRequest, TResponse>()
            where TRequest : IRequest<TResponse>
        {
            return Container().GetRequiredService<IRequestHandler<TRequest, TResponse>>();
        }

        public static ApplicationContext GetDatabaseContext()
        {
            return Container().GetRequiredService<ApplicationContext>();
        }

        public static void ClearDatabase()
        {
            var context = GetDatabaseContext();

            context.Users.RemoveRange(context.Users);

            context.SaveChanges();
        }

        private static IServiceProvider Container()
        {
            if (_provider == null)
            {
                var services = new ServiceCollection();

                services.AddCoreApplication();

                services.AddIdentity<Customer, IdentityRole<Guid>>()
                    .AddEntityFrameworkStores<ApplicationContext>()
                    .AddDefaultTokenProviders();

                services.AddAuthentication();

                services.AddLogging();

                services.AddSqlServer<ApplicationContext>(
                    "Server=(localdb)\\mssqllocaldb;Database=ASC.Tests;Trusted_Connection=True;MultipleActiveResultSets=true");

                _provider = services.BuildServiceProvider();
            }

            return _provider;
        }
}
}
