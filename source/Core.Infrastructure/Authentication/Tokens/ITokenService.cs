using System.Security.Claims;

namespace Core.Infrastructure.Authentication.Tokens
{
    /// <summary>
    /// Service for the generation of auth token.
    /// </summary>
    public interface ITokenService
    {
        /// <summary>
        /// Generates a short lived access token from an <see cref="IEnumerable{Claim}"/>.
        /// </summary>
        /// <param name="claims">An <see cref="IEnumerable{Claim}"/>.</param>
        /// <returns>A string based access token.</returns>
        public string GenerateAccessToken(IEnumerable<Claim> claims);

        /// <summary>
        /// Generates a long lived refresh token.
        /// </summary>
        /// <returns>A string based refresh token.</returns>
        public string GenerateRefreshToken();
    }
}
