using System.ComponentModel.DataAnnotations;
using Core.Application.Common.Responses;

namespace Core.Application.Customers.AddCustomer
{
    public class AddCustomerResponse : ApplicationResponse
    {
        public AddCustomerResponse(string username, string email)
        {
            Username = username;
            Email = email;
        }

        public AddCustomerResponse(Status status, string errorMessage)
            : base(status, errorMessage)
        {
            Username = string.Empty;
            Email = string.Empty;
        }

        [Required]
        public string Username { get; }

        [Required]
        public string Email { get; }
    }
}
