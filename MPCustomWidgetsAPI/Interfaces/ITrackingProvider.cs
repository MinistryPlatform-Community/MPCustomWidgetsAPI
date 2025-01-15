namespace MicroServices.Interfaces
{
    public interface ITrackingProvider
    {
        Task AddTrackingData(string eventName, Dictionary<string, object> properties);
    }
}
