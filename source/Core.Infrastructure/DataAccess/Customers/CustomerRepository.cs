using Core.Application.Customers.Common;
using Core.Domain.Customers;
using Microsoft.AspNetCore.Identity;

namespace Core.Infrastructure.DataAccess.Customers
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly UserManager<Customer> _userManager;

        public CustomerRepository(UserManager<Customer> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> AddCustomer(Customer customer, string password)
        {
            return await _userManager.CreateAsync(customer, password);
        }
    }
}
