using Ical.Net;
using Ical.Net.CalendarComponents;
using Ical.Net.DataTypes;
using Ical.Net.Serialization;
using Microservices.Models;
using Microservices.Providers;
using MicroServices.Converters;
using MicroServices.Interfaces;
using MicroServices.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NodaTime.TimeZones;
using NodaTime;
using System.Net.Mail;
using System.Text;

namespace MicroServices.Controllers
{
    /// <summary>
    /// Returns Event Data
    /// </summary>
    [EnableCors("WideOpenPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;
        private readonly ITrackingProvider _trackingProvider;

        private const string eventName = "Event Data";

        public EventsController(IEventRepository eventRepository, IHttpContextAccessor httpContextAccessor, ITrackingProvider trackingProvider)
        {
            _eventRepository = eventRepository;
            _trackingProvider = trackingProvider;
        }

        /// <summary>
        /// Generates iCAL Files for Events
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="GetFeaturedEventsOnly"></param>
        /// <param name="GetRegistrationEventsOnly"></param>
        /// <param name="EventTypeIDs"></param>
        /// <param name="MinistryIDs"></param>
        /// <param name="CongregationIDs"></param>
        /// <param name="ProgramIDs"></param>
        /// <param name="VisibilityLevelIDs"></param>
        /// <param name="OnlyApprovedEvents"></param>
        /// <param name="OnlyUnApprovedEvents"></param>
        /// <param name="ShowExtendedData"></param>
        /// <param name="ShowExtendedDataNotes"></param>
        /// <param name="RoomIDs"></param>
        /// <param name="LocationIDs"></param>
        /// <param name="ServiceIDs">Retrieve events based on Event Servicing IDs</param>
        /// <param name="EventID">Retrieve a single Event.  NOTE - This overrides most options (EventTypeIDs, MinistryIDs, CongregationIDs, etc)</param>
        /// <param name="BaseEventUrl">Url to an event details page.  [Event_ID] will be appended directly to this url</param>
        /// <param name="DataFormat">json, ical-file or ical(default)</param>
        /// <param name="convertToUTC">Converts datetime objects from Domain Time to UTC</param>
        /// <param name="cacheData">Cache Data for 5 minutes and use cached data</param>
        /// <returns></returns>        
        [HttpGet]
        [Route("GetEvents")]
        public async Task<IActionResult> GetEvents
        (
            [FromQuery] DateTime? startDate = null,
            [FromQuery] DateTime? endDate = null,
            [FromQuery] bool GetFeaturedEventsOnly = false,
            [FromQuery] bool GetRegistrationEventsOnly = false,
            [FromQuery] List<int>? EventTypeIDs = null,
            [FromQuery] List<int>? MinistryIDs = null,
            [FromQuery] List<int>? CongregationIDs = null,
            [FromQuery] List<int>? ProgramIDs = null,
            [FromQuery] List<int>? VisibilityLevelIDs = null,
            [FromQuery] bool OnlyApprovedEvents = true,
            [FromQuery] bool OnlyUnApprovedEvents = false,
            [FromQuery] bool ShowExtendedData = false,
            [FromQuery] bool ShowExtendedDataNotes = false,
            [FromQuery] List<int>? RoomIDs = null,
            [FromQuery] List<int>? LocationIDs = null,
            [FromQuery] List<int>? ServiceIDs = null,
            [FromQuery] int? EventID = null,
            [FromQuery] string? BaseEventUrl = null,
            [FromQuery] string DataFormat = "ical",
            [FromQuery] bool convertToUTC = false,
            [FromQuery] bool cacheData = true
        )
        {
            var trackingData = new Dictionary<string, object>();

            if (VisibilityLevelIDs == null || !VisibilityLevelIDs.Any())
            {     
                VisibilityLevelIDs = new List<int>();
                VisibilityLevelIDs.Add(4);
            }

            if (!startDate.HasValue)
            {
                startDate = DateTime.Now.AddMonths(-1);
            }

            if (!endDate.HasValue)
            {
                endDate = DateTime.Now.AddMonths(12);
            }

            if (DataFormat.ToLower().Trim() == "json")
            {
                trackingData.Add("dataType", "json");
            }
            else
            {
                trackingData.Add("dataType", "iCal");
            }

            var cacheKey = $"{Request.Host}|Events|{Request.QueryString}";

            if (cacheData && CacheProvider.CheckForCacheItem(cacheKey))
            {
                trackingData.Add("cacheHit", true);
                await _trackingProvider.AddTrackingData(eventName, trackingData);

                if (DataFormat.ToLower().Trim() == "ical-file")
                {
                    string content = CacheProvider.GetItem<string>(cacheKey);
                    var byteArray = Encoding.UTF8.GetBytes(content);
                    string contentType = "text/calendar";
                    string downloadFileName = $"EventDownload.ics";

                    // Return the byte array as a file
                    return File(byteArray, contentType, downloadFileName);
                }
                else
                {
                    // Return Cached item as string
                    return Content(CacheProvider.GetItem<string>(cacheKey), "text/calendar");
                }
            }
            
            // Get Event Data
            var events = await _eventRepository.GetEvents(
            startDate: startDate.Value,
            endDate: endDate.Value,
            GetFeaturedEventsOnly: GetFeaturedEventsOnly,
            GetRegistrationEventsOnly: GetRegistrationEventsOnly,
            EventTypeIDs: EventTypeIDs,
            MinistryIDs: MinistryIDs,
            CongregationIDs: CongregationIDs,
            ProgramIDs: ProgramIDs,
            VisibilityLevelIDs: VisibilityLevelIDs,
            OnlyApprovedEvents: OnlyApprovedEvents,
            ShowExtendedData: ShowExtendedData,
            ShowExtendedDataNotes: ShowExtendedDataNotes,
            RoomIDs: RoomIDs,
            LocationIDs: LocationIDs,
            ServiceIDs: ServiceIDs,
            EventID: EventID,
            BaseEventUrl: BaseEventUrl, 
            convertToUTC: convertToUTC);

            if (DataFormat.ToLower().Trim() == "json")
            {
                //Add Data to Cache
                if (cacheData)
                {
                    CacheProvider.AddItem<string>(cacheKey, 5, JsonConvert.SerializeObject(events, Formatting.Indented, new ResultSetCustomConverter()));
                }
                await _trackingProvider.AddTrackingData(eventName, trackingData);                
                return Ok(events);
            }

            var calendar = new Calendar();

            // Get MP Domain Data
            var _domain = await _eventRepository.GetDomainInfoAsync();
            
            // Convert .NET timezone name to NodaTime BclDateTimeZone
            DateTimeZone nodaTimeZone = BclDateTimeZone.FromTimeZoneInfo(TimeZoneInfo.FindSystemTimeZoneById(_domain.TimeZoneName));

            if (convertToUTC)
            {
                nodaTimeZone = BclDateTimeZone.Utc;
            }
            
            calendar.ProductId = "MP ICal Generator";
            calendar.Method = "Publish";

            foreach (var e in events)
            {
                var vEvent = new CalendarEvent()
                {
                    DtStart = new CalDateTime(e.Event_Start_Date, nodaTimeZone.Id),
                    DtEnd = new CalDateTime(e.Event_End_Date, nodaTimeZone.Id),
                    Summary = e.Event_Title,
                    Description = e.Description,
                    Location = e.Location_Name,
                    Uid = $"MPEventID-{e.Event_ID}"
                };

                //
                // Categories
                //
                List<string> categories = new List<string>();
                categories.Add(e.Location_Name);

                vEvent.Categories = categories;


                //
                // Attachment
                // 
                var attachItem = new Ical.Net.DataTypes.Attachment();

                if (!String.IsNullOrWhiteSpace(e._DefaultImage))
                {
                    try
                    {
                        attachItem.Uri = new Uri(e._DefaultImage);
                        attachItem.FormatType = "image/png";
                        vEvent.Attachments.Add(attachItem);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }

                }

                //
                // URL
                //
                if (!String.IsNullOrWhiteSpace(BaseEventUrl))
                {
                    try
                    {
                        vEvent.Url = new Uri($"{BaseEventUrl}{e.Event_ID}");
                    }
                    catch { }                    
                }


                //
                // Extended Data
                //
                if (ShowExtendedData)
                {
                    vEvent.Description += $"\n\n";

                    if (e.Rooms != null && e.Rooms.Any())
                    {
                        if (e.Rooms.Count > 1)
                        {
                            vEvent.Description += "Rooms:";
                        }
                        else
                        {
                            vEvent.Description += "Room:";
                        }

                        foreach (var r in e.Rooms)
                        {
                            vEvent.Description += $" {r.Room_Name},";

                            if (ShowExtendedDataNotes)
                            {
                                vEvent.Resources.Add($"Room-{r.Room_Name} | {r.Notes}");
                            }
                            else
                            {
                                vEvent.Resources.Add($"Room-{r.Room_Name}");
                            }                            
                        }

                        vEvent.Description = vEvent.Description.TrimEnd(',');

                    }

                    if (e.Servicing != null && e.Servicing.Any())
                    {
                        vEvent.Description += $"\n\nServices:";

                        foreach (var s in e.Servicing)
                        {
                            vEvent.Description += $" {s.Service_Name},";

                            if (ShowExtendedDataNotes)
                            {
                                vEvent.Resources.Add($"Service-{s.Service_Name} | {s.Notes}");
                            }
                            else
                            {
                                vEvent.Resources.Add($"Service-{s.Service_Name}");
                            }
                            
                        }
                        vEvent.Description = vEvent.Description.TrimEnd(',');
                    }

                    if (e.Equipment != null && e.Equipment.Any())
                    {
                        vEvent.Description += $"\n\nEquipment:";

                        foreach (var s in e.Equipment)
                        {
                            vEvent.Description += $" {s.Equipment_Name},";
                            vEvent.Resources.Add($"Equipment-{s.Equipment_Name}");
                        }
                        vEvent.Description = vEvent.Description.TrimEnd(',');
                    }
                }

                calendar.Events.Add(vEvent);    
            }


            //Initialize iCal serializer
            CalendarSerializer serializer = new CalendarSerializer();

            //Add Data to Cache
            if (cacheData)
            {
                CacheProvider.AddItem<string>(cacheKey, 5, serializer.SerializeToString(calendar));
            }

            await _trackingProvider.AddTrackingData(eventName, trackingData);

            
            // Return the iCal calendar as a file
            if (DataFormat.ToLower().Trim() == "ical-file")
            {
                string content = serializer.SerializeToString(calendar);
                var byteArray = Encoding.UTF8.GetBytes(content);
                string contentType = "text/calendar";
                string downloadFileName = $"EventDownload.ics";

                // Return the byte array as a file
                return File(byteArray, contentType, downloadFileName);
            }
            else
            {
                //Return the iCal calendar as string    
                return Content(serializer.SerializeToString(calendar), "text/calendar");
            }
        }
    }
}
