namespace Core.Infrastructure.Authentication.Tokens
{
    public class TokenConfiguration
    {
        public TokenConfiguration(string audience, string issuer, string key)
        {
            Audience = audience;
            Issuer = issuer;
            Key = key;
        }

        public string Audience { get; }

        public string Issuer { get; }

        public string Key { get; }
    }
}
