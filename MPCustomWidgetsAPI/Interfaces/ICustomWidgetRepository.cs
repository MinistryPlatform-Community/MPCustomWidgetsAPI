using MicroServices.Models;
using Platform.Clients.PowerService;

namespace MicroServices.Interfaces
{
    public interface ICustomWidgetRepository
    {
        Task<ResultSet> GetWidgetData(string storedProcedure, string? userName, string? spParams);
    }
}
