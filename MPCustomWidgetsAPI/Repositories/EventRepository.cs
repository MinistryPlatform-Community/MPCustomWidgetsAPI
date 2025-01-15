using Microservices.Interfaces;
using Microservices.Providers;
using Microservices.Repositories;
using MicroServices.Interfaces;
using MicroServices.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Newtonsoft.Json;

namespace MicroServices.Repositories
{
    public class EventRepository : _BaseRepository, IEventRepository
    {
        private readonly IDomainProvider _domainProvider;
        private readonly string EventSelect = "Events.*, Program_ID_TABLE.Ministry_ID, Event_Type_ID_Table.Event_Type AS Event_Type, dp_fileUniqueId AS _DefaultImageGUID, Location_ID_Table.Location_Name, Congregation_ID_Table.Congregation_Name AS _Congregation_Name, Program_ID_Table.Program_Name";
        private readonly string EventSubPageSelect = "Event_ID_TABLE.*, Event_ID_TABLE_Event_Type_ID_Table.Event_Type AS Event_Type, Event_ID_TABLE.dp_fileUniqueId AS _DefaultImageGUID, Event_ID_TABLE_Location_ID_Table.Location_Name, Event_ID_TABLE_Congregation_ID_Table.Congregation_Name AS _Congregation_Name, Event_ID_TABLE_Program_ID_Table.Program_Name";

        #region Constructor
        public EventRepository(IDomainProvider domainProvider) : base(domainProvider)
        {
            _domainProvider = domainProvider;
        }
        #endregion

        #region Public Methods
        public async Task<IEnumerable<EventViewModel>> GetEvents
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
        )
        {
            var _domain = await GetDomainInfoAsync();
            // Define the source timezone and the target timezone
            TimeZoneInfo sourceTimeZone = TimeZoneInfo.FindSystemTimeZoneById(_domain.TimeZoneName);
            TimeZoneInfo targetTimeZone = TimeZoneInfo.Utc;

            IEnumerable<EventRoomViewModel> rooms = null;
            IEnumerable<EventServiceViewModel> services = null;
            IEnumerable<EventEquipmentViewModel> equipment = null;
            IEnumerable<EventViewModel> events = null;

            if (EventID.HasValue)
            {
                // Get all Future Events in Series....IF in Series
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@EventID", EventID.Value);

                var eventSeries = await mp.ExecuteStoredProcedureAsync(
                    procedure: "api_Common_GetEventsInSeries",
                    parameters: parameters);

                if (eventSeries != null && eventSeries.First().Any())
                {
                    var seriesData = DynamicListToType<EventSeriesListViewModel>(eventSeries.First());
                    
                    if (seriesData != null && seriesData.Any())
                    {
                        events = await mp.GetRecordsAsync<EventViewModel>(
                             table: "Events",
                             filter: $"Events.Event_ID IN ({String.Join(',', seriesData.Select(x=>x.Event_ID))})",
                             select: EventSelect,
                             orderBy: "Event_Start_Date");
                    }
                }
                
                if (events == null)
                {
                    events = await mp.GetRecordsAsync<EventViewModel>(
                        table: "Events",
                        filter: $"Events.Event_ID={EventID}",
                        select: EventSelect,
                        orderBy: "Event_Start_Date");
                }
            }
            else if (ServiceIDs != null && ServiceIDs.Any())
            {
                // Setup Base Filter
                string filter = $"Event_ID_TABLE.Event_Start_Date >='{startDate.ToString()}' AND Event_ID_TABLE.Event_End_Date < '{endDate.ToString()}' AND Event_ID_TABLE.Cancelled = 0";

                // Add Visibility IDs
                filter += $" AND Event_ID_TABLE.Visibility_Level_ID IN ({String.Join(",", VisibilityLevelIDs)})";

                // Add Service IDs
                filter += $" AND Service_ID IN ({String.Join(",", ServiceIDs)})";

                // Featured Events Modifier
                if (GetFeaturedEventsOnly)
                {
                    filter += String.Format(" AND Event_ID_TABLE.Featured_On_Calendar=1");
                }

                // Get Registration Events ONLY
                if (GetRegistrationEventsOnly)
                {
                    filter += $" AND ((Event_ID_TABLE.Online_Registration_Product IS NOT NULL OR Event_ID_TABLE.External_Registration_URL IS NOT NULL) AND ISNULL(Event_ID_TABLE.Registration_Start, Event_ID_TABLE.Event_Start_Date) >= '{startDate.ToShortDateString()}' AND INULL(Event_ID_TABLE.Registration_End, Event_ID_TABLE.Event_End_Date) <= '{endDate.ToShortDateString()}')";
                }

                if (MinistryIDs != null && MinistryIDs.Any())
                {
                    filter += $" AND Event_ID_TABLE.Program_ID_Table.Ministry_ID IN ({String.Join(",", MinistryIDs)})";
                }

                if (CongregationIDs != null && CongregationIDs.Any())
                {
                    filter += $" AND Event_ID_TABLE.Congregation_ID IN ({String.Join(",", CongregationIDs)})";
                }

                if (LocationIDs != null && LocationIDs.Any())
                {
                    filter += $" AND Event_ID_TABLE.Location_ID IN ({String.Join(",", LocationIDs)})";
                }

                if (ProgramIDs != null && ProgramIDs.Any())
                {
                    filter += $" AND Event_ID_TABLE.Program_ID IN ({String.Join(",", ProgramIDs)})";
                }

                if (OnlyApprovedEvents)
                {
                    filter += " AND Event_ID_TABLE._Web_Approved=1 AND Event_ID_TABLE._Approved=1";
                }
                else if (OnlyUnApprovedEvents)
                {
                    filter += " AND (Event_ID_TABLE._Web_Approved = 0 OR Event_ID_TABLE._Approved = 0)";
                }

                events = await mp.GetRecordsAsync<EventViewModel>(
                    table: "Event_Services",
                    filter: filter,
                    select: EventSubPageSelect,
                    orderBy: "Event_ID_TABLE.Event_Start_Date"
                    );
            }
            else
            {
                // Setup Base Filter
                string filter = $"Event_Start_Date >='{startDate.ToString()}' AND Event_End_Date < '{endDate.ToString()}' AND Cancelled = 0";

                // Add Visibility IDs
                filter += $" AND Visibility_Level_ID IN ({String.Join(",", VisibilityLevelIDs)})";



                // Featured Events Modifier
                if (GetFeaturedEventsOnly)
                {
                    filter += String.Format(" AND Featured_On_Calendar=1");
                }

                // Get Registration Events ONLY
                if (GetRegistrationEventsOnly)
                {
                    filter += $" AND ((Online_Registration_Product IS NOT NULL OR External_Registration_URL IS NOT NULL) AND ISNULL(Registration_Start, Event_Start_Date) >= '{startDate.ToShortDateString()}' AND INULL(Registration_End, Event_End_Date) <= '{endDate.ToShortDateString()}')";
                }

                if (MinistryIDs != null && MinistryIDs.Any())
                {
                    filter += $" AND Program_ID_Table.Ministry_ID IN ({String.Join(",", MinistryIDs)})";
                }

                if (CongregationIDs != null && CongregationIDs.Any())
                {
                    filter += $" AND Events.Congregation_ID IN ({String.Join(",", CongregationIDs)})";
                }

                if (LocationIDs != null && LocationIDs.Any())
                {
                    filter += $" AND Events.Location_ID IN ({String.Join(",", LocationIDs)})";
                }

                if (ProgramIDs != null && ProgramIDs.Any())
                {
                    filter += $" AND Events.Program_ID IN ({String.Join(",", ProgramIDs)})";
                }

                if (OnlyApprovedEvents)
                {
                    filter += " AND _Web_Approved=1 AND _Approved=1";
                }
                else if (OnlyUnApprovedEvents)
                {
                    filter += " AND (_Web_Approved = 0 OR _Approved = 0)";
                }

                events = await mp.GetRecordsAsync<EventViewModel>(
                    table: "Events",
                    filter: filter,
                    select: EventSelect,
                    orderBy: "Event_Start_Date"
                    );
            }

            if (ShowExtendedData && events.Any())
            {
                // Get Rooms
                rooms = await mp.GetRecordsAsync<EventRoomViewModel>(
                    table:"Event_Rooms", 
                    filter: String.Format("Event_ID IN ({0})", String.Join(",", events.Select(x => x.Event_ID))), 
                    select: "Event_ID, Room_ID_Table.*, Room_ID_Table_Building_ID_Table.Building_Name"
                );

                // Get Servicing
                services = await mp.GetRecordsAsync<EventServiceViewModel>(
                    table: "Event_Services", 
                    filter: String.Format("Event_ID IN ({0})", String.Join(",", events.Select(x => x.Event_ID))), 
                    select: "Event_ID, Service_ID_Table.*, Event_Services.Notes"
                );
                // Resources
                equipment = await mp.GetRecordsAsync<EventEquipmentViewModel>(
                    table: "Event_Equipment",
                    filter: String.Format("Event_ID IN ({0})", String.Join(",", events.Select(x => x.Event_ID))),
                    select: "Event_ID, Equipment_ID_Table.*"
                );
            }

            string filesEndpoint = _domainProvider.GetMinistryPlatformProvider().GetFilesEndpoint();

            foreach (var e in events)
            {
                if (!String.IsNullOrWhiteSpace(e._DefaultImageGUID))
                {
                    e._DefaultImage = $"{filesEndpoint}/{e._DefaultImageGUID}";
                }

                if (rooms != null && rooms.Any())
                {
                    e.Rooms = rooms.Where(x => x.Event_ID == e.Event_ID).ToList();
                }

                if (services != null && services.Any())
                {
                    e.Servicing = services.Where(x => x.Event_ID == e.Event_ID).ToList();
                }

                if (equipment != null && equipment.Any())
                {
                    e.Equipment = equipment.Where(x => x.Event_ID == e.Event_ID).ToList();
                }

                if (convertToUTC)
                {
                    e.Event_Start_Date = ConvertTimeZoneToUTC(e.Event_Start_Date, sourceTimeZone);

                    e.Event_End_Date = ConvertTimeZoneToUTC(e.Event_End_Date, sourceTimeZone);
                }
                else
                {
                    // Output with Correct Timezone INformation
                    e.Event_Start_Date = TimeZoneInfo.ConvertTime(e.Event_Start_Date, sourceTimeZone);

                    e.Event_End_Date = TimeZoneInfo.ConvertTime(e.Event_End_Date, sourceTimeZone);
                }
            }

            // Return the data
            return events;
        }
        #endregion

        #region Private Methods
        private DateTime ConvertTimeZoneToUTC(DateTime source, TimeZoneInfo sourceTimeZone)
        {
            // Create a DateTime object in Unspecified
            DateTime sourceDateTime = DateTime.SpecifyKind(source, DateTimeKind.Unspecified);

            // Convert to correct TimeZone
            return TimeZoneInfo.ConvertTimeToUtc(sourceDateTime, sourceTimeZone);
        }

        /// <summary>
        /// Method that converts a dyanmic object to the passed Type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns>T</returns>
        private T DynamicToType<T>(dynamic obj)
        {
            var tempObj = JsonConvert.SerializeObject(obj);
            return JsonConvert.DeserializeObject<T>(tempObj);
        }

        /// <summary>
        /// Method to Convert IEnumerable&lt;dynamic&gt; to IEnumerable&lt;T&gt;
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns>IEnumerable&lt;T&gt;</returns>
        private IEnumerable<T> DynamicListToType<T>(IEnumerable<dynamic> obj)
        {
            ICollection<T> objOut = new List<T>();

            foreach (var o in obj)
            {
                objOut.Add(DynamicToType<T>(o));
            }

            return objOut;
        }
        #endregion
    }
}
