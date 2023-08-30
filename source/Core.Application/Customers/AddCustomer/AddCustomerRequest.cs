using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Core.Domain.Customers;
using MediatR;

namespace Core.Application.Customers.AddCustomer
{
    /// <summary>
    /// A request object for the creation of a new <see cref="Customer"/>.
    /// </summary>
    public class AddCustomerRequest : IRequest<AddCustomerResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddCustomerRequest"/> class.
        /// </summary>
        /// <param name="userName">The userName for the <see cref="Customer"/>.</param>
        /// <param name="email">The email for the <see cref="Customer"/>.</param>
        /// <param name="password">The password for the <see cref="Customer"/>.</param>
        [JsonConstructor]
        public AddCustomerRequest(string userName, string email, string password)
        {
            UserName = userName;
            Email = email;
            Password = password;
        }

        /// <summary>
        /// Gets the UserName for the future <see cref="Customer"/>.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public string UserName { get; }

        /// <summary>
        /// Gets the Email for the future <see cref="Customer"/>.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [EmailAddress]
        public string Email { get; }

        /// <summary>
        /// Gets the Password for the future <see cref="Customer"/>.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [RegularExpression(PasswordRequirements.PasswordRegex)]
        [MinLength(PasswordRequirements.MinimumPasswordLength)]
        public string Password { get; }
    }
}
