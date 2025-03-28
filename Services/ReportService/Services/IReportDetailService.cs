using Common.DTOs;
using Common.Models;
using ReportService.DTOs;

namespace ReportService.Services
{
    public interface IReportDetailService
    {
        Task<ServiceResponse<ReportDetailDto>> GetReportDetailByReportIdAsync(Guid reportId);
        Task<ServiceResponse<string>> SaveReportDetailAsync(ReportGeneratedDto reportGeneratedDto);
    }
    
}