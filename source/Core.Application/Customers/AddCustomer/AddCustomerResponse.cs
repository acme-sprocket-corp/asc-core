using System.ComponentModel.DataAnnotations;

namespace Core.Application.Customers.AddCustomer
{
    public class AddCustomerResponse
    {
        public AddCustomerResponse(string? username, string? email)
            : this()
        {
            Username = username;
            Email = email;
        }

        public AddCustomerResponse()
        {
        }

        [Required]
        public string? Username { get; }

        [Required]
        public string? Email { get; }
    }
}
