using Microservices.Models;
using Microservices.Providers;

namespace Microservices.Interfaces
{
    public interface IDomainProvider
    {
        DomainConnectionModel GetDomainInfo();
        MinistryPlatformProvider GetMinistryPlatformProvider();
    }
}
