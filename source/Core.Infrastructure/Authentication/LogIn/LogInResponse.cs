using System.ComponentModel.DataAnnotations;
using Core.Application.Common.Responses;

namespace Core.Infrastructure.Authentication.LogIn
{
    public class LogInResponse : ApplicationResponse
    {
        public LogInResponse(string accessToken, string refreshToken)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }

        public LogInResponse(Status status, string errorMessage)
            : base(status, errorMessage)
        {
            AccessToken = string.Empty;
            RefreshToken = string.Empty;
        }

        [Required]
        public string AccessToken { get; }

        [Required]
        public string RefreshToken { get; }
    }
}
