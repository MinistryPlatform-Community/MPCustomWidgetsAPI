using Microservices.Models;
using Microservices.Providers;
using MicroServices.Converters;
using MicroServices.Interfaces;
using MicroServices.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Platform.Clients.PowerService;
using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;

namespace MicroServices.Controllers
{
    /// <summary>
    /// Enables Data Requests for Custom Widgets
    /// </summary>
    [EnableCors("WideOpenPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomWidgetController : ControllerBase
    {
        private readonly ICustomWidgetRepository _widget;
        private readonly ITrackingProvider _trackingProvider;

        /// <summary>
        /// Tracking Event Name
        /// </summary>
        private const string eventName = "CustomWidget";

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="widgetRepository"></param>
        /// <param name="trackingProvider"></param>
        public CustomWidgetController(ICustomWidgetRepository widgetRepository, ITrackingProvider trackingProvider)
        {
            _widget = widgetRepository;
            _trackingProvider = trackingProvider;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Get Custom Widget Data from Stored Procedure
        /// </summary>
        /// <param name="storedProcedure"></param>
        /// <param name="userData"></param>
        /// <param name="cacheData"></param>
        /// <param name="requireUser"></param>
        /// <param name="spParams"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        [HttpGet]
        public async Task<IActionResult> GetWidgetData(string storedProcedure, string? spParams = null, string? userData = null, bool cacheData = true, bool requireUser = false)
        {
            // Init userName
            string? userName = null;

            try
            {
                if (String.IsNullOrWhiteSpace(storedProcedure))
                {
                    return BadRequest(new { error = "Stored procedure must be provided" });
                }

                if (!storedProcedure.ToLower().StartsWith("api_custom"))
                {
                    return BadRequest(new { error = "Stored procedure name must begin with api_custom" });
                }

                if (userData != null)
                {
                    try
                    {
                        //TODO: Verify Token Integrity

                        var jwtHandler = new JwtSecurityTokenHandler();
                        var jwtSecurityToken = jwtHandler.ReadToken(userData) as JwtSecurityToken;
                        if (jwtSecurityToken != null && jwtSecurityToken.Claims != null)
                        {
                            userName = jwtSecurityToken.Claims.First(claim => claim.Type == "name").Value;
                        }
                    }
                    catch
                    {
                        userName = null;
                    }         
                }

                if (requireUser && userName == null)
                {
                    // Return Unauthorized because the User is not logged in
                    return Unauthorized(new { error = "Authentication required" });
                }

                string cacheKey = $"{storedProcedure}|{requireUser}";
                if (userName != null)
                {
                    cacheKey += $"|{userName}";
                }

                if (spParams != null)
                {
                    cacheKey += $"|{Base64Encode(spParams)}";
                }

                var trackingData = new Dictionary<string, object>();
                trackingData.Add("storedProcedure", storedProcedure);            
                trackingData.Add("cached", cacheData);

                if (cacheData && CacheProvider.CheckForCacheItem(cacheKey))
                {                
                    trackingData.Add("cacheHit", true);
                    await _trackingProvider.AddTrackingData(eventName, trackingData);
                    return Ok(CacheProvider.GetItem<string>(cacheKey));
                }

                ResultSet widgetData = null;

                widgetData = await _widget.GetWidgetData(storedProcedure, userName, spParams);

                if (!widgetData.Any())
                {
                    return NotFound(new { error = $"No data found for {storedProcedure}" });
                }

                string json = JsonConvert.SerializeObject(widgetData, Formatting.Indented, new ResultSetCustomConverter());

                if (cacheData)
                {
                    CacheProvider.AddItem<string>(cacheKey, 5, json);
                }

                // Track First Data or Uncached Requests as NOT a cache Hit
                trackingData.Add("cacheHit", false);

                await _trackingProvider.AddTrackingData(eventName, trackingData);

                return Ok(json);

            }
            catch (Exception ex)
            {
                // Return a generic error message
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = "Custom Widget API Internal Error Occurred", details = ex.Message });
            }
        }
        #endregion

        #region Private Methods
        private string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        #endregion
    }
}
