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
            try
            {
                var contactEntity = contact.Adapt<Contact>();


                if (String.IsNullOrEmpty(contact.DisplayName))
                {
                    contactEntity.DisplayName = string.Format("{0} {1} {2}", contact.Salutation, contact.FirstName, contact.LastName); ;
                }
                contactEntity.NotifyHasBirthdaySoon = CheckIfNotifyHasBirthdaySoon(contactEntity.BirthDate);
                var result = await _contactRepository.AddAsync(contactEntity);
                return new ServiceResponse<ContactDto>(contact);
            }
            catch (Exception ex)
            {

                return new ServiceResponse<ContactDto>(contact) { IsSuccess = false, Message = ex.Message };
            }


        }

        public async Task<ServiceResponse<ContactDto>> UpdateContact(int id, ContactDto contact)
        {
            try
            {
                var contactEntity = contact.Adapt<Contact>();
                contactEntity.Id = id;
                if (String.IsNullOrEmpty(contact.DisplayName))
                {
                    contactEntity.DisplayName = string.Format("{0} {1} {2}", contact.Salutation, contact.FirstName, contact.LastName); ;
                }
                await _contactRepository.UpdateAsync(contactEntity);
                return new ServiceResponse<ContactDto>(contact);
            }
            catch (Exception ex)
            {

                return new ServiceResponse<ContactDto>(contact) { IsSuccess = false, Message = ex.Message };
            }

        }

        public async Task<ServiceResponse<int>> DeleteContactById(int id)
        {
            try
            {
                var contactEntity = await _contactRepository.GetByIdAsync(id);
                _contactRepository.Remove(contactEntity);
                return new ServiceResponse<int>(id) { IsSuccess = true, Message = "Successfully deleted" };
            }
            catch (Exception ex)
            {

                return new ServiceResponse<int>(id) { IsSuccess = true, Message = ex.Message };
            }

        }
        public async Task<ServiceResponse<Contact>> GetContactById(int contactId)
        {
            try
            {
                var contactEntity = await _contactRepository.GetByIdAsync(contactId);
                return new ServiceResponse<Contact>(contactEntity) { IsSuccess = true };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<Contact>(new Contact { }) { IsSuccess = false, Message = ex.Message };
            }
        }
        public async Task<ServiceResponse<List<Contact>>> GetAllContacts()
        {
            try
            {
                var contactEntityList = await _contactRepository.GetAllAsync();
                return new ServiceResponse<List<Contact>>(contactEntityList.ToList()) { IsSuccess = true };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<List<Contact>>(new List<Contact> { }) { IsSuccess = false, Message = ex.Message };
                throw;
            }

        }

        private bool CheckIfNotifyHasBirthdaySoon(DateTime birthdate)
        {
            TimeSpan daysUntilBirthday = birthdate.Date - DateTime.Today.Date;
            return (daysUntilBirthday >= TimeSpan.Zero && daysUntilBirthday <= TimeSpan.FromDays(14)) ? true : false;
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        }

    }
}
