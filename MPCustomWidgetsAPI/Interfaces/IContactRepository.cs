using Microservices.Models;

namespace MicroServices.Interfaces
{
    public interface IContactRepository
    {
        Task<ContactModel> Get(int id);
    }
}
