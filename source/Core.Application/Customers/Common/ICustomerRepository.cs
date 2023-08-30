using Core.Domain.Customers;
using Microsoft.AspNetCore.Identity;

namespace Core.Application.Customers.Common
{
    /// <summary>
    /// Repository interface for Customers. Synonymous with Identity Users.
    /// </summary>
    public interface ICustomerRepository
    {
        /// <summary>
        /// Adds a <see cref="Customer"/> to the application persistence.
        /// </summary>
        /// <param name="customer">The <see cref="Customer"/> instance to add.</param>
        /// <param name="password">The <see cref="Customer"/> password of alphanumeric values.</param>
        /// <returns>A <see cref="Task"/> of type <see cref="IdentityResult"/> representing the operation.</returns>
        Task<IdentityResult> AddCustomer(Customer customer, string password);

        /// <summary>
        /// Updates an existing <see cref="Customer"/>.
        /// </summary>
        /// <param name="customer">The <see cref="Customer"/> to be updated.</param>
        /// <returns>A <see cref="Task"/> of type <see cref="IdentityResult"/> representing the operation.</returns>
        Task<IdentityResult> UpdateCustomer(Customer customer);

        /// <summary>
        /// Attempts to return a <see cref="Customer"/> via a unique username.
        /// </summary>
        /// <param name="userName">The username of the <see cref="Customer"/> to be searched against.</param>
        /// <returns>A <see cref="Task"/> of type <see cref="Customer"/> representing the operation.</returns>
        Task<Customer?> FindCustomerByName(string userName);

        /// <summary>
        /// Looks to see if the given password matches a <see cref="Customer"/>.
        /// </summary>
        /// <param name="customer">The <see cref="Customer"/> to check the password for.</param>
        /// <param name="password">The password attempting to be validated against the <see cref="Customer"/>.</param>
        /// <returns>A <see cref="Task"/> of type bool representing the operation.</returns>
        Task<bool> CheckCustomerPassword(Customer customer, string password);
    }
}
