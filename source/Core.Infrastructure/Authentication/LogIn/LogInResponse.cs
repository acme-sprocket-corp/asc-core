using System.ComponentModel.DataAnnotations;

namespace Core.Infrastructure.Authentication.LogIn
{
    /// <summary>
    /// The response object from a user attempting to logIn.
    /// </summary>
    public class LogInResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LogInResponse"/> class.
        /// </summary>
        /// <param name="accessToken">The access token for the user.</param>
        /// <param name="refreshToken">The refresh token for the user.</param>
        public LogInResponse(string accessToken, string refreshToken)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }

        /// <summary>
        /// Gets the short lived access token.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public string AccessToken { get; }

        /// <summary>
        /// Gets the longer lived refresh token.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public string RefreshToken { get; }
    }
}
