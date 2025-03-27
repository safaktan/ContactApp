using ReportService.Models;

namespace ReportService.Repositories
{
    public interface IReportRepository
    {
        Task<IEnumerable<Report>> GetAllReportsAsync();
    }
}