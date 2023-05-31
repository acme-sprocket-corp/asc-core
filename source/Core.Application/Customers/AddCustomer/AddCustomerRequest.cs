using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using MediatR;

namespace Core.Application.Customers.AddCustomer
{
    public class AddCustomerRequest : IRequest<AddCustomerResponse>
    {
        [JsonConstructor]
        public AddCustomerRequest(string userName, string email, string password)
        {
            UserName = userName;
            Email = email;
            Password = password;
        }

        [Required(AllowEmptyStrings = false)]
        public string UserName { get; }

        [Required(AllowEmptyStrings = false)]
        [EmailAddress]
        public string Email { get; }

        [Required(AllowEmptyStrings = false)]
        public string Password { get; }
    }
}
