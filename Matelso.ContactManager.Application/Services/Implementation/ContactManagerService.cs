using Mapster;
using Matelso.ContactManager.Application.Interfaces.Repositories;
using Matelso.ContactManager.Application.Interfaces.Services;
using Matelso.ContactManager.Application.Responses;
using Matelso.ContactManager.Application.Validation;
using Matelso.ContactManager.Domain.Contracts;
using Matelso.ContactManager.Domain.Entities;

namespace Matelso.ContactManager.Application.Services.Implementation
{
    public class ContactManagerService : IContactManagerService
    {
        private readonly IContactRepository _contactRepository;
        private readonly ContactValidator _contactValidator;

        public ContactManagerService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
            //_contactValidator = contactValidator;
        }

        public async Task<ServiceResponse<ContactDto>> CreateContact(ContactDto contact)
        {
            //var validator = new ContactValidator(_contactRepository);
            //var validationResult = await _contactValidator.ValidateAsync(contact);
            var contactEntity = contact.Adapt<Contact>();
            //var validationResult = await _contactValidator.ValidateAsync(contact);

            //if (validationResult != null)
            //{
            //    return new ServiceResponse<ContactDto>(contact) { IsSuccess = false, };
            //}

            if (String.IsNullOrEmpty(contact.DisplayName))
            {
                contactEntity.DisplayName = string.Format("{0} {1} {2}", contact.Salutation, contact.FirstName, contact.LastName); ;
            }

            var result = await _contactRepository.AddAsync(contactEntity);
            return new ServiceResponse<ContactDto>(contact);
        }

        public async Task<ServiceResponse<ContactDto>> UpdateContact(ContactDto contact)
        {
            var contactEntity = contact.Adapt<Contact>();
            if (String.IsNullOrEmpty(contact.DisplayName))
            {
                contactEntity.DisplayName = string.Format("{0} {1} {2}", contact.Salutation, contact.FirstName, contact.LastName); ;
            }
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

    }
}
