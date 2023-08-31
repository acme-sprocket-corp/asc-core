using System.ComponentModel.DataAnnotations;

namespace Core.Application.Customers.AddCustomer
{
    /// <summary>
    /// The response object for adding a new customer.
    /// </summary>
    public class AddCustomerResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddCustomerResponse"/> class.
        /// </summary>
        /// <param name="userName">The userName of the new customer.</param>
        /// <param name="email">The email of the new customer.</param>
        public AddCustomerResponse(string userName, string email)
        {
            UserName = userName;
            Email = email;
        }

        /// <summary>
        /// Gets the UserName of the newly added customer.
        /// </summary>
        [Required]
        public string UserName { get; }

        /// <summary>
        /// Gets the Email of the newly added customer.
        /// </summary>
        [Required]
        public string Email { get; }
    }
}
