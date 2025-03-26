using System.ComponentModel.DataAnnotations;

namespace ContactService.Models
{
    public class ContactDetail
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? PhoneNumber { get; set; }
        [EmailAddress]
        public string? EmailAddress { get; set; }
        public string? Location { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Guid ContactId { get; set; }
        public Contact Contact { get; set; }
    }
}