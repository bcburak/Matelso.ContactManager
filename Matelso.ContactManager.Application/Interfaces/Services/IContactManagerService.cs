using Matelso.ContactManager.Domain.Contracts;

namespace Matelso.ContactManager.Application.Interfaces.Services
{
    public interface IContactManagerService
    {
        Task<bool> CreateContact(ContactDto contact);
        Task<bool> UpdateContact(ContactDto contact);
        Task<bool> DeleteContact(ContactDto contact);
        Task<bool> GetContactById(int contactId);
        Task<bool> GetAllContacts();

    }
}
