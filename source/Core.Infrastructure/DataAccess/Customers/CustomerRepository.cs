// <copyright file="CustomerRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Core.Application.Customers.Common;
using Core.Domain.Customers;
using Microsoft.AspNetCore.Identity;

namespace Core.Infrastructure.DataAccess.Customers
{
    /// <inheritdoc />
    public class CustomerRepository : ICustomerRepository
    {
        private readonly UserManager<Customer> _userManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerRepository"/> class.
        /// </summary>
        /// <param name="userManager">An instance of <see cref="UserManager{TUser}"/>.</param>
        public CustomerRepository(UserManager<Customer> userManager)
        {
            _userManager = userManager;
        }

        /// <inheritdoc/>
        public async Task<IdentityResult> AddCustomer(Customer customer, string password)
        {
            return await _userManager.CreateAsync(customer, password);
        }

        /// <inheritdoc/>
        public async Task<bool> CheckCustomerPassword(Customer customer, string password)
        {
            return await _userManager.CheckPasswordAsync(customer, password);
        }

        /// <inheritdoc/>
        public async Task<Customer?> FindCustomerByName(string userName)
        {
            return await _userManager.FindByNameAsync(userName);
        }

        /// <inheritdoc/>
        public async Task<IdentityResult> UpdateCustomer(Customer customer)
        {
            return await _userManager.UpdateAsync(customer);
        }
    }
}
