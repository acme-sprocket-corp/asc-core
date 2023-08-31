namespace Core.Infrastructure.Authentication.Tokens
{
    /// <summary>
    /// Container for all JWT related properties.
    /// </summary>
    public class TokenConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TokenConfiguration"/> class.
        /// </summary>
        /// <param name="audience">The token audience.</param>
        /// <param name="issuer">The token issuer.</param>
        /// <param name="key">The token key.</param>
        public TokenConfiguration(string audience, string issuer, string key)
        {
            Audience = audience;
            Issuer = issuer;
            Key = key;
        }

        /// <summary>
        /// Gets the token Audience.
        /// </summary>
        public string Audience { get; }

        /// <summary>
        /// Gets the token Issuer.
        /// </summary>
        public string Issuer { get; }

        /// <summary>
        /// Gets the token Key.
        /// </summary>
        public string Key { get; }
    }
}
