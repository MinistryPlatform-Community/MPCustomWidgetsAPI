namespace MicroServices.Models
{
    public class DataFormattingViewModel
    {
        public IEnumerable<IDictionary<string, Object>> dataPayload { get; set; }
        public string mainTemplate { get; set; }
        public string itemTemplate { get; set; }
        public string templateItemObject { get; set; }

        
    }
}
