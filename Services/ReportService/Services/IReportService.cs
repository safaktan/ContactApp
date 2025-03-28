using Common.DTOs;
using Common.Models;
using ReportService.DTOs;
using ReportService.Models;

namespace ReportService.Services
{
    public interface IReportService
    {
        Task<ServiceResponse<IEnumerable<ReportDto>>> GetAllReportsAsync();
        Task<ServiceResponse<string>> UpdateReportStatusByIdAsync(Guid id, string status);
        Task<ServiceResponse<string>> ReportRequest(RabbitMqRequestDto rabbitMqRequestDto);
        Task<ServiceResponse<ReportDto>> CreateReport();
    }
}