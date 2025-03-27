using Common.Models;
using ReportService.DTOs;

namespace ReportService.Services
{
    public interface IReportService
    {
        Task<ServiceResponse<IEnumerable<ReportDto>>> GetAllReportsAsync();
    }
}