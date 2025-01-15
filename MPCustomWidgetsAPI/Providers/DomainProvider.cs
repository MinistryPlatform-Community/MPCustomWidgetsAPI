using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Platform.Clients.PowerService;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microservices.Interfaces;
using Microservices.Models;
using System.Configuration;

namespace Microservices.Providers
{
    public class DomainProvider: IDomainProvider
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _context;
        private readonly IWebHostEnvironment _env;

        public DomainProvider(IConfiguration configuration, IHttpContextAccessor context, IWebHostEnvironment env) 
        { 
            _configuration = configuration;
            _context = context;
            _env = env;
        }

        public DomainConnectionModel GetDomainInfo()
        {
            var requestHost = _context.HttpContext.Request.Host.Host;
            
            var saasAPI = _configuration.GetValue<string>("MPSAAS:API");
            var saasClient = _configuration.GetValue<string>("MPSAAS:ClientID");
            var saasSecret = _configuration.GetValue<string>("MPSAAS:Secret");
            bool useSAAS = true;

            try
            {
                useSAAS = _configuration.GetValue<bool>("MPSAAS:useSAAS");
            }
            catch { useSAAS = true; }

            if (!useSAAS)
            {
                DomainConnectionModel localModel = new DomainConnectionModel()
                {
                    APIUrl = _configuration.GetValue<string>("MinistryPlatform:API"),
                    OAuthClientId = _configuration.GetValue<string>("MinistryPlatform:ClientID"),
                    OAuthClientSecret = _configuration.GetValue<string>("MinistryPlatform:Secret"),
                    Encryption_Key = _configuration.GetValue<string>("MinistryPlatform:Encryption_Key")
                };

                return localModel;
            }


            if (String.IsNullOrWhiteSpace(saasAPI) || String.IsNullOrWhiteSpace(saasClient) || String.IsNullOrWhiteSpace(saasSecret))
            {
                return null;
            }

            IPowerService client = PowerServiceClientFactory.CreateAsync(new Uri(saasAPI),
                saasClient, saasSecret).Result;

            var appClient = _configuration.GetValue<string>("MPSAAS:appClientID");

            var response = client.GetRecordsAsync<DomainConnectionModel>(
                table: "Oauth_Credentials",
                select: "Saas_Domain_ID_Table.OAuth_Metadata_Address AS OAuthBaseUrl, Client_Secret AS JwtSecureKey, Saas_Domain_ID_Table.Service_Address AS APIUrl, Client_ID AS OAuthClientId, Client_Secret AS OAuthClientSecret, Encryption_Key AS Encryption_Key",
                filter: $"Saas_Domain_ID_Table.Host_Name='{requestHost}' AND Client_ID='{appClient}'").Result;

            if (!response.Any())
            {
                throw new Exception($"Could not find SaaS OAuth Credentials for Host_Name='{requestHost}' AND Client_ID='{appClient}'");
            }

            return response.FirstOrDefault();

        }

        public MinistryPlatformProvider GetMinistryPlatformProvider()
        {
            var cacheItemKey = $"{_context.HttpContext.Request.Host.Host}-mp-provider";

            if (CacheProvider.CheckForCacheItem(cacheItemKey))
            {
                return CacheProvider.GetItem<MinistryPlatformProvider>(cacheItemKey);
            }

            var _mp = new MinistryPlatformProvider(_configuration, GetDomainInfo());
            CacheProvider.AddItem<MinistryPlatformProvider>(cacheItemKey, 60, _mp);

            return _mp;
        }
    }
}
