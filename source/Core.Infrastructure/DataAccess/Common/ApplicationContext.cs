// <copyright file="ApplicationContext.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using Core.Domain.Customers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Core.Infrastructure.DataAccess.Common
{
    /// <summary>
    /// Context class for application persistence.
    /// </summary>
    public sealed class ApplicationContext : IdentityDbContext<Customer, IdentityRole<Guid>, Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationContext"/> class.
        /// </summary>
        /// <param name="options">An instance of <see cref="DbContextOptions"/> for configuration.</param>
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
