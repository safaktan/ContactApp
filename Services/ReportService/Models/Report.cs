using System.ComponentModel.DataAnnotations;
using Common.Constants;

namespace ReportService.Models
{
    public class Report
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime RequestedDate { get; set; }
        public string Status { get; set; } = ReportStatus.ReportPreparing;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public ReportDetail ReportDetail { get; set; }
    }
    
}