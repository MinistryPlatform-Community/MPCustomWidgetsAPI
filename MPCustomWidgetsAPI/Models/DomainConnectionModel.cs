using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace Microservices.Models
{
    public class DomainConnectionModel
    {
        private const string OAUTH_DISCOVERY_ENDPOINT = ".well-known/openid-configuration";

        public string OAuthBaseUrl { get; set; }
        public string OAuthClientId { get; set; }
        public string OAuthClientSecret { get; set; }
        public string APIUrl { get; set; }
        public string JwtSecureKey { get; set; }
        public string Encryption_Key { get; set; }

        public OpenIdConnectConfiguration Configuration { get; set; }

        public string OAuthDiscoveryUrl
        {
            get
            {
                return OAuthBaseUrl.EndsWith('/') ? $"{OAuthBaseUrl}{OAUTH_DISCOVERY_ENDPOINT}" : $"{OAuthBaseUrl}/{OAUTH_DISCOVERY_ENDPOINT}";
            }
        }
    }
}
