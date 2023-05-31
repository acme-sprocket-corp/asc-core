using Core.Domain.Customers;
using Microsoft.AspNetCore.Identity;

namespace Core.Application.Customers.Common
{
    public interface ICustomerRepository
    {
        Task<IdentityResult> AddCustomer(Customer customer, string password);

        Task<IdentityResult> UpdateCustomer(Customer customer);
    }
}
