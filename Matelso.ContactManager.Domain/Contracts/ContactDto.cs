using System.ComponentModel.DataAnnotations;

namespace Matelso.ContactManager.Domain.Contracts
{
    public class ContactDto
    {
        [Required]
        public string Salutation { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public DateTime? BirthDate { get; set; }

        [Required]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
