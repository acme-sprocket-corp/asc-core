// <copyright file="Authorization.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Text;
using Core.Domain.Customers;
using Core.Infrastructure.Authentication.Tokens;
using Core.Infrastructure.DataAccess.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Core.Infrastructure.Dependencies
{
    /// <summary>
    /// Class for Auth related dependencies.
    /// </summary>
    public static class Authorization
    {
        /// <summary>
        /// Adds Auth related dependencies to the IOC container.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> container.</param>
        /// <param name="tokenConfiguration">A <see cref="TokenConfiguration"/> instance to configure token properties.</param>
        public static void AddJwtAuthorization(this IServiceCollection services, TokenConfiguration tokenConfiguration)
        {
            services.AddIdentity<Customer, IdentityRole<Guid>>()
                .AddEntityFrameworkStores<ApplicationContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequiredLength = PasswordRequirements.MinimumPasswordLength;
            });

            services.AddAuthorization();

            services.AddSingleton(_ => tokenConfiguration);

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
                    ValidAudience = tokenConfiguration.Audience,
                    ValidIssuer = tokenConfiguration.Issuer,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenConfiguration.Key)),
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                };
            });
        }
    }
}
