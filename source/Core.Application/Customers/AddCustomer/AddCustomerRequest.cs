// <copyright file="AddCustomerRequest.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Core.Application.Common.Responses;
using Core.Domain.Customers;

namespace Core.Application.Customers.AddCustomer
{
    /// <summary>
    /// A request object for the creation of a new <see cref="Customer"/>.
    /// </summary>
    public class AddCustomerRequest : IEnvelopeRequest<AddCustomerResponse>
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
