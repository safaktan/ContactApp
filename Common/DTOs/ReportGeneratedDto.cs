namespace Common.DTOs
{
    public class ReportGeneratedDto
    {
        public Guid ReportId { get; set; }
        public List<ReportResultDto> ReportResultDtoList { get; set; }
    }
}