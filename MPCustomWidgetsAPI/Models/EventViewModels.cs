using Microservices.Models;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace MicroServices.Models
{
    public class EventViewModel
    {

        public int Event_ID { get; set; }
        public string Event_Title { get; set; }
        public int Event_Type_ID { get; set; }
        public string Event_Type { get; set; }       
        public int Congregation_ID { get; set; }
        public string Congregation_Name { get; set; }
        public int? Location_ID { get; set; }
        public string Location_Name { get; set; }
        public string Meeting_Instructions { get; set; }
        public string Description { get; set; }
        public int Program_ID { get; set; }
        public int Ministry_ID { get; set; }
        public string Program_Name { get; set; }

        public int? Participants_Expected { get; set; }
        public DateTime Event_Start_Date { get; set; }
        public DateTime Event_End_Date { get; set; }

        public int Visibility_Level_ID { get; set; }

        public bool Cancelled { get; set; }
        public bool? _Approved { get; set; }
        public bool? _Web_Approved { get; set; }
        
        public bool Featured_On_Calendar { get; set; }

        public bool Registration_Active { get; set; }
        public bool Minor_Registration { get; set; }
        

        public string _DefaultImageGUID { get; set; }
        public string _DefaultImage { get; set; }

        public bool Show_Building_Room_Info { get; set; }

        public List<EventRoomViewModel> Rooms { get; set; }
        public List<EventServiceViewModel> Servicing { get; set; }
        public List<EventEquipmentViewModel> Equipment { get; set; }

        public EventViewModel()
        {
            Rooms = new List<EventRoomViewModel>();
            Servicing = new List<EventServiceViewModel>();
            Equipment = new List<EventEquipmentViewModel>();
        }
    }

    public class EventRoomViewModel : EventRoomModel
    {
        public string Room_Name { get; set; }
        public string Building_Name { get; set; }
    }

    public class EventServiceViewModel : ServicingModel
    {
        public int Event_ID { get; set; }
        public string Notes { get; set; }
    }

    public class EventEquipmentViewModel : EquipmentModel
    {
        public int Event_ID { get; set; }
    }

    public class EventSeriesListViewModel
    {
        public int Event_ID { get; set; }
    }

    public class SimpleCalendarJsonViewModel
    {
        public string id { get; set; }
        public string calendarId { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        public string location { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public bool isReadOnly { get; set; }
        public string raw { get; set; }
    }
}
