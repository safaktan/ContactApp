using ReportService.Models;

namespace ReportService.Repositories
{
    public interface IReportRepository
    {
        Task<IEnumerable<Report>> GetAllReportsAsync();
        Task<bool> UpdateReportStatusByIdAsync(Guid id, string status);
        Task<Report> GetReportByIdAsync(Guid id);
        Task<Report> CreateReport(Report report);
    }
}