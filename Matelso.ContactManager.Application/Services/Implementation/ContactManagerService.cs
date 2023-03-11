using Mapster;
using Matelso.ContactManager.Application.Interfaces.Repositories;
using Matelso.ContactManager.Application.Interfaces.Services;
using Matelso.ContactManager.Application.Responses;
using Matelso.ContactManager.Domain.Contracts;
using Matelso.ContactManager.Domain.Entities;

namespace Matelso.ContactManager.Application.Services.Implementation
{
    public class ContactManagerService : IContactManagerService
    {
        private readonly IContactRepository _contactRepository;

        public ContactManagerService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<ServiceResponse<ContactDto>> CreateContact(ContactDto contact)
        {
            var contactEntity = contact.Adapt<Contact>();
            var result = await _contactRepository.AddAsync(contactEntity);
            return new ServiceResponse<ContactDto>(contact);
        }

        public async Task<ServiceResponse<ContactDto>> UpdateContact(ContactDto contact)
        {
            var contactEntity = contact.Adapt<Contact>();
            await _contactRepository.UpdateAsync(contactEntity);
            return new ServiceResponse<ContactDto>(contact);
        }

        public async Task<ServiceResponse<int>> DeleteContactById(int id)
        {
            var contactEntity = await _contactRepository.GetByIdAsync(id);
            _contactRepository.Remove(contactEntity);
            return new ServiceResponse<int>(id);
        }
        public async Task<ServiceResponse<Contact>> GetContactById(int contactId)
        {
            var contactEntity = await _contactRepository.GetByIdAsync(contactId);
            return new ServiceResponse<Contact>(contactEntity);
        }
        public async Task<ServiceResponse<List<Contact>>> GetAllContacts()
        {
            var contactEntityList = await _contactRepository.GetAllAsync();
            return new ServiceResponse<List<Contact>>(contactEntityList.ToList());
        }

        //public async Task<bool> CheckIfEmailIsExist(string email)
        //{
        //    return await _contactRepository.CheckEmailByEmailAddress(email);
        //}
    }
}
