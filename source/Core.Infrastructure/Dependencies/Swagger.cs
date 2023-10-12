// <copyright file="Swagger.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Core.Infrastructure.Dependencies
{
    /// <summary>
    /// Adds all Swagger dependencies.
    /// </summary>
    public static class Swagger
    {
        /// <summary>
        /// Adds all Swagger related dependencies.
        /// </summary>
        /// <param name="services">The IOC container.</param>
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer thisIsMyToken\"",
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme, Id = "Bearer",
                            },
                        },
                        Array.Empty<string>()
                    },
                });
            });
        }
    }
}
