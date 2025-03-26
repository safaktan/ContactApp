using System.ComponentModel.DataAnnotations;

namespace ContactService.Models
{
    public class Contact
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        public string? Company { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public List<ContactDetail> ContactDetails { get; set; } = new List<ContactDetail>();
    }
}