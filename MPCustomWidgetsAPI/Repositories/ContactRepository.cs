using Microservices.Interfaces;
using Microservices.Models;
using Microservices.Repositories;
using MicroServices.Interfaces;

namespace MicroServices.Repositories
{
    public class ContactRepository: _BaseRepository, IContactRepository
    {
        #region Constructor
        public ContactRepository(IDomainProvider domainProvider) : base(domainProvider)
        {

        }
        #endregion

        #region Public Methods
        public async Task<ContactModel> Get(int id)
        {
            return await mp.GetRecordAsync<ContactModel>(
                table: "Contacts",
                id: id);
        }

        #endregion

        #region Private Methods

        #endregion
    }
}
