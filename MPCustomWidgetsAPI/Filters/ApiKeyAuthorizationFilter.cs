using MicroServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MicroServices.Filters
{
    public class ApiKeyAuthorizationFilter: IAuthorizationFilter
    {
        private const string ApiKeyHeaderName = "X-API-KEY";

        private readonly IApiKeyProvider _apiKeyValidator;

        public ApiKeyAuthorizationFilter(IApiKeyProvider apiKeyValidator)
        {
            _apiKeyValidator = apiKeyValidator;
        }

        public void OnAuthorization(AuthorizationFilterContext filterContext)
        {
            string apiKey = filterContext.HttpContext.Request.Headers[ApiKeyHeaderName];

            if (!_apiKeyValidator.IsValid(apiKey))
            {
                filterContext.Result = new UnauthorizedResult();
            }
        }
    }
}
