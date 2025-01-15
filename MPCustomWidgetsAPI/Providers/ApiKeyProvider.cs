using Microservices.Interfaces;
using Microservices.Providers;
using MicroServices.Interfaces;

namespace MicroServices.Providers
{
    public class ApiKeyProvider : IApiKeyProvider
    {
        private readonly IDomainProvider _domainProvider;

        public ApiKeyProvider(IDomainProvider domainProvider) 
        { 
            _domainProvider = domainProvider;
        }
        
        public bool IsValid(string apiKey)
        {            
            string validApiKey = _domainProvider.GetMinistryPlatformProvider().GetEncryptionKey();

            // Don't allow null or empty APIKeys
            if (String.IsNullOrEmpty(apiKey))
            {
                return false;
            }

            if (validApiKey == apiKey)
            {
                return true;
            }
            
            return false;                       
        }
    }
}
