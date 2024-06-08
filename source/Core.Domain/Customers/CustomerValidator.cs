// <copyright file="CustomerValidator.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using FluentValidation;

namespace Core.Domain.Customers
{
    /// <summary>
    /// Validator object for a <see cref="Customer"/>.
    /// </summary>
    public class CustomerValidator : AbstractValidator<Customer>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerValidator"/> class.
        /// </summary>
        public CustomerValidator()
        {
            RuleFor(customer => customer.UserName).NotNull().NotEmpty();
            RuleFor(customer => customer.Email).EmailAddress();
        }
    }
}
