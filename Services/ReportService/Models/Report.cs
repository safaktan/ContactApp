using System.ComponentModel.DataAnnotations;

namespace ReportService.Models
{
    public class Report
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime RequestedDate { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public ReportDetail ReportDetail { get; set; }
    }
    
}