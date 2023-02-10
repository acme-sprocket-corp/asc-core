using System.Text.Json.Serialization;
using Core.Application.Common.Responses;
using MediatR;

namespace Core.Application.Customers.AddCustomer
{
    public class AddCustomerRequest : IRequest<Envelope<string>>
    {
        [JsonConstructor]
        public AddCustomerRequest(string username, string email, string password)
        {
            Username = username;
            Email = email;
            Password = password;
        }

        public string Username { get; }

        public string Email { get; }

        public string Password { get; }
    }
}
