using System.ComponentModel.DataAnnotations;
using Core.Application.Common.Responses;
using MediatR;

namespace Core.Application.Customers.AddCustomer
{
    public class AddCustomerRequest : IRequest<Envelope<AddCustomerResponse>>
    {
        public AddCustomerRequest(string username, string email, string password)
        {
            Username = username;
            Email = email;
            Password = password;
        }

        [Required(AllowEmptyStrings = false)]
        public string Username { get; }

        [Required(AllowEmptyStrings = false)]
        [EmailAddress]
        public string Email { get; }

        [Required(AllowEmptyStrings = false)]
        public string Password { get; }
    }
}
