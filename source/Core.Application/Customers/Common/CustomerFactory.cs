using Core.Application.Common.Responses;
using Core.Application.Customers.AddCustomer;
using Core.Domain.Customers;
using Microsoft.AspNetCore.Identity;

namespace Core.Application.Customers.Common
{
    public class CustomerFactory
    {
        public Customer CreateCustomer(AddCustomerRequest request)
        {
            return new Customer(request.Username, request.Email);
        }

        public Envelope<AddCustomerResponse> CreateCustomerResponse(IdentityResult result, Customer customer)
        {
            if (result.Succeeded)
            {
                return Envelope<AddCustomerResponse>.Success(new AddCustomerResponse(customer.UserName, customer.Email));
            }

            var errors = result.Errors.FirstOrDefault() != null ? result.Errors.First().Description : string.Empty;

            return Envelope<AddCustomerResponse>.Failure(Status.AuthenticationError, errors);
        }
    }
}
