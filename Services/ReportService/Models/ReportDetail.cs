namespace ReportService.Models
{
    public class ReportDetail
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Location {get; set;}
        public int ContactCount { get; set; }
        public int PhoneNumberCount { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Guid ReportId { get; set; }
        public Report Report { get; set; }
    }
}