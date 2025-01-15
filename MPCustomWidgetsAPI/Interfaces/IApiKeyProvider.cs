namespace MicroServices.Interfaces
{
    public interface IApiKeyProvider
    {
        bool IsValid(string apiKey);
    }
}
