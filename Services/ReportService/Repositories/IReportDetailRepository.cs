using ReportService.Models;

namespace ReportService.Repositories
{
    public interface IReportDetailRepository
    {
        Task<ReportDetail> GetReportDetailByReportIdAsync(Guid reportId);
    }
}