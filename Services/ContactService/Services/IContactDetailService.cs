using Common.DTOs;
using Common.Models;
using ContactService.DTOs;

namespace ContactService.Services
{
    public interface IContactDetailService
    {
        Task<ServiceResponse<List<CreateContactDetailResponseDto>>> CreateContactDetailAsync(CreateContactDetailDto createContactDetailDto);
        Task<ServiceResponse<ContactInfoAndDetailResponseDto>> GetContactInfoAndDetailByContactIdAsync(Guid contactId);
        Task<ServiceResponse<string>> DeleteAllContactDetailByContactIdAsync(Guid contactId);
        Task<ServiceResponse<List<ReportResultDto>>> GetReportDataByLocationAsync();
    }
    
}