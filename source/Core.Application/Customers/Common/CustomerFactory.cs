// <copyright file="CustomerFactory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Core.Application.Common.Responses;
using Core.Application.Customers.AddCustomer;
using Core.Domain.Customers;
using Microsoft.AspNetCore.Identity;

namespace Core.Application.Customers.Common
{
    /// <summary>
    /// A factory for objects and responses related to a <see cref="Customer"/>.
    /// </summary>
    public static class CustomerFactory
    {
        /// <summary>
        /// Creates a new <see cref="Customer"/> from a <see cref="AddCustomerRequest"/>.
        /// </summary>
        /// <param name="request">An instance of <see cref="AddCustomerRequest"/>.</param>
        /// <returns>A new <see cref="Customer"/> instance.</returns>
        public static Customer CreateCustomer(AddCustomerRequest request)
        {
            return new Customer(request.UserName, request.Email);
        }

        /// <summary>
        /// Creates a new <see cref="AddCustomerResponse"/> from an <see cref="IdentityResult"/> and <see cref="Customer"/>.
        /// </summary>
        /// <param name="result">The <see cref="IdentityResult"/> from object creation.</param>
        /// <param name="customer">The initial <see cref="Customer"/> being added to persistence.</param>
        /// <returns>An <see cref="IEnvelope{AddCustomerResponse}"/> instance.</returns>
        public static IEnvelope<AddCustomerResponse> CreateCustomerResponse(IdentityResult result, Customer customer)
        {
            if (result.Succeeded)
            {
                return Envelope<AddCustomerResponse>.Success(new AddCustomerResponse(customer.UserName, customer.Email));
            }

            var errors = result.Errors.FirstOrDefault() != null ? result.Errors.First().Description : string.Empty;

            return Envelope<AddCustomerResponse>.Failure(ApplicationStatus.AuthenticationError, errors);
        }
    }
}
