namespace ReportService.DTOs
{
    public class ReportDto
    {
        public Guid Id{ get; set; }
        public DateTime RequestedDate{ get; set; }
        public string Status{ get; set; }
    }
}