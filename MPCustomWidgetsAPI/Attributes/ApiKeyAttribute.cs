using MicroServices.Filters;
using Microsoft.AspNetCore.Mvc;

namespace MicroServices.Attributes
{
    public class ApiKeyAttribute: ServiceFilterAttribute
    {
        public ApiKeyAttribute():
            base(typeof(ApiKeyAuthorizationFilter))
        {

        }
    }
}
