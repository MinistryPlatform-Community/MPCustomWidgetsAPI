using MicroServices.Interfaces;
using Microservices.Repositories;
using Microservices.Interfaces;
using Platform.Clients.PowerService;

namespace MicroServices.Repositories
{
    public class CustomWidgetRepository : _BaseRepository, ICustomWidgetRepository
    {
        #region Constructor
        public CustomWidgetRepository(IDomainProvider domainProvider) : base(domainProvider)
        {

        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Returns Data to a Widget from Stored Procedure
        /// </summary>
        /// <param name="storedProcedure"></param>
        /// <returns></returns>
        public async Task<ResultSet> GetWidgetData(string storedProcedure, string? userName, string? spParams)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            if (userName != null)
            {
                parameters.Add("@userName", userName);
            }

            if (spParams != null)
            {
                foreach (var p in spParams.Split('&'))
                {
                    var paramParts = p.Split('=');
                    if (paramParts.Length == 2)
                    {
                        parameters.Add(paramParts[0], paramParts[1]);
                    }
                }
            }

            return await mp.ExecuteStoredProcedureAsync(
                procedure: storedProcedure,
                parameters: parameters);
        }
        #endregion

        #region Private Methods

        #endregion
    }
}
