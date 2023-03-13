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
        /// <summary>
        /// Create new contact with contact fields
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        [HttpPost("CreateContact")]
        public async Task<ActionResult<ContactDto>> CreateContact(ContactDto contact)
        {
            var result = await _contactManager.CreateContact(contact);
            return Ok(result);
        }

        /// <summary>
        /// Update the contact with contact fields and Id which is already created before
        /// </summary>
        /// <param name="id"></param>
        /// <param name="contact"></param>
        /// <returns></returns>
        [HttpPut("UpdateContact/{id}")]
        public async Task<IActionResult> UpdateContact(int id, ContactDto contact)
        {
            var result = await _contactManager.UpdateContact(id, contact);
            return Ok(result);
        }

        /// <summary>
        /// Delete the contact record by contact id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpDelete("DeleteContact/{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var result = await _contactManager.DeleteContactById(id);

            return Ok(result);
        }
        /// <summary>
        /// Get the contact record by contact id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("GetContactById/{id}")]
        public async Task<ActionResult<ContactDto>> GetContactById(int id)
        {
            var result = await _contactManager.GetContactById(id);

            return Ok(result);
        }

        /// <summary>
        /// Get all created contact list
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactDto>>> GetAllContacts()
        {
            var result = await _contactManager.GetAllContacts();

            return Ok(result);
        }
    }
}