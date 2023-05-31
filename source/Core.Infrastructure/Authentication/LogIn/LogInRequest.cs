using System.Text.Json.Serialization;
using MediatR;

namespace Core.Infrastructure.Authentication.LogIn
{
    public class LogInRequest : IRequest<LogInResponse>
    {
        [JsonConstructor]
        public LogInRequest(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        public string UserName { get; }

        public string Password { get; }
    }
}
