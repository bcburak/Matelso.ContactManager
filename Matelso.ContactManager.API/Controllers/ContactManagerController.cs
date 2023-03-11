using Matelso.ContactManager.Application.Interfaces.Services;
using Matelso.ContactManager.Domain.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Matelso.ContactManager.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactManagerController : ControllerBase
    {
        private readonly IContactManagerService _contactManager;
        public ContactManagerController(IContactManagerService contactManager)
        {
            _contactManager = contactManager;
        }
        [HttpPost]
        public async Task<ActionResult<ContactDto>> CreateContact(ContactDto contact)
        {
            var result = await _contactManager.CreateContact(contact);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContact(int id, ContactDto contact)
        {
            var result = await _contactManager.UpdateContact(contact);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var result = await _contactManager.DeleteContactById(id);

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ContactDto>> GetContactById(int id)
        {
            var result = await _contactManager.GetContactById(id);

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactDto>>> GetContacts()
        {
            var result = await _contactManager.GetAllContacts();
            //return await _dbContext.Contacts.ToListAsync();
            return Ok(result);
        }
    }
}