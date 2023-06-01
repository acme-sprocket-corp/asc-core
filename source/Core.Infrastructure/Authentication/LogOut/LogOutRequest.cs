using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using MediatR;

namespace Core.Infrastructure.Authentication.LogOut
{
    public class LogOutRequest : IRequest<LogOutResponse>
    {
        [JsonConstructor]
        public LogOutRequest(string userName)
        {
            UserName = userName;
        }

        [Required(AllowEmptyStrings = false)]
        public string UserName { get; }
    }
}
