using MicroServices.Interfaces;
using Mixpanel;

namespace MicroServices.Providers
{
    /// <summary>
    /// Provider for sending usage data to Mixpanel
    /// </summary>
    public class TrackingProvider: ITrackingProvider
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string token;
        private readonly string secret;
        private readonly MixpanelClient _mc;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="httpContextAccessor"></param>
        public TrackingProvider(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            token = _configuration.GetValue<string>("MixPanelConfig:token");
            secret = _configuration.GetValue<string>("MixPanelConfig:secret");
            _mc = new MixpanelClient(token);
        }

        /// <summary>
        /// Add Tracking Data to Mixpanel
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="properties"></param>
        /// <returns></returns>
        public async Task AddTrackingData(string eventName, Dictionary<string, object> properties)
        {
            // Added Null MixPanel Token Detection
            if (String.IsNullOrWhiteSpace(token))
            {
                return;
            }

            properties.Add("host", _httpContextAccessor.HttpContext.Request.Host.Host);
            await _mc.TrackAsync(eventName, properties);
        }
    }
}
