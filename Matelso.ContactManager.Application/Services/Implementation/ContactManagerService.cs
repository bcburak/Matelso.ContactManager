using Matelso.ContactManager.Application.Interfaces.Repositories;
using Matelso.ContactManager.Application.Interfaces.Services;
using Matelso.ContactManager.Domain.Contracts;

namespace Matelso.ContactManager.Application.Services.Implementation
{
    public class ContactManagerService : IContactManagerService
    {
        private readonly IContactRepository _contactRepository;

        public ContactManagerService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<bool> CreateContact(ContactDto contact)
        {
            return true;
        }

        public async Task<bool> UpdateContact(ContactDto contact)
        {
            return true;
        }

        public async Task<bool> DeleteContact(ContactDto contact)
        {
            return true;
        }
        public async Task<bool> GetContactById(int contactId)
        {
            return true;
        }
        public async Task<bool> GetAllContacts()
        {
            return true;
        }
    }
}
