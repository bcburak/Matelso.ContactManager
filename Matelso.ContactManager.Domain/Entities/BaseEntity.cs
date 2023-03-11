using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Matelso.ContactManager.Domain.Entities
{
    public class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreationTimestamp { get; set; }

        public DateTime? LastChangeTimestamp { get; set; }
    }
}
