using Matelso.ContactManager.Application.Responses;
using Matelso.ContactManager.Domain.Contracts;
using Matelso.ContactManager.Domain.Entities;

namespace Matelso.ContactManager.Application.Interfaces.Services
{
    public interface IContactManagerService
    {
        Task<ServiceResponse<ContactDto>> CreateContact(ContactDto contact);
        Task<ServiceResponse<ContactDto>> UpdateContact(int id, ContactDto contact);
        Task<ServiceResponse<int>> DeleteContactById(int id);
        Task<ServiceResponse<Contact>> GetContactById(int contactId);
        Task<ServiceResponse<List<Contact>>> GetAllContacts();
        //Task<bool> CheckIfEmailIsExist(string email);

    }
}
