using MicroServices.Models;
using Platform.Clients.PowerService;

namespace MicroServices.Interfaces
{
    public interface IEventRepository
    {
        Task<IEnumerable<EventViewModel>> GetEvents
        (
            DateTime startDate,
            DateTime endDate,
            bool GetFeaturedEventsOnly = false,
            bool GetRegistrationEventsOnly = false,
            List<int>? EventTypeIDs = null,
            List<int>? MinistryIDs = null,
            List<int>? CongregationIDs = null,
            List<int>? ProgramIDs = null,
            List<int>? VisibilityLevelIDs = null,
            bool OnlyApprovedEvents = true,
            bool OnlyUnApprovedEvents = false,
            bool ShowExtendedData = false,
            bool ShowExtendedDataNotes = false,
            List<int>? RoomIDs = null,
            List<int>? LocationIDs = null,
            List<int>? ServiceIDs = null,
            int? EventID = null,
            string? BaseEventUrl = null,
            bool convertToUTC = false
        );

        Task<DomainInfo> GetDomainInfoAsync();
    }
}
