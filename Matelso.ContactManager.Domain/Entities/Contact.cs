using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Matelso.ContactManager.Domain.Entities
{
    public class Contact : BaseEntity
    {

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Salutation { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string LastName { get; set; }

        [StringLength(100)]
        public string DisplayName { get; set; }

        public DateTime? BirthDate { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public bool NotifyHasBirthdaySoon { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(20)]
        public string PhoneNumber { get; set; }
    }
}
