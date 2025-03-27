using AutoMapper;
using Common.Models;
using ReportService.DTOs;
using ReportService.Repositories;

namespace ReportService.Services
{
    public class ReportDetailService : IReportDetailService
    {
        private readonly IMapper _mapper;
        private readonly IReportDetailRepository _reportDetailRepository;

        public ReportDetailService(IMapper mapper, IReportDetailRepository reportDetailRepository)
        {
            _mapper = mapper;
            _reportDetailRepository = reportDetailRepository;
        }
        public async Task<ServiceResponse<ReportDetailDto>> GetReportDetailByReportIdAsync(Guid reportId)
        {
            try
            {
                var reportDetail = await _reportDetailRepository.GetReportDetailByReportIdAsync(reportId);
                if (reportDetail == null)
                {
                    return ServiceResponse<ReportDetailDto>.Failure("Report Detail Not Found");
                }
                var reportDetailDtoItem = _mapper.Map<ReportDetailDto>(reportDetail);
                return ServiceResponse<ReportDetailDto>.Success(reportDetailDtoItem);

            }
            catch (System.Exception ex)
            {
                return ServiceResponse<ReportDetailDto>.Failure(ex.Message);
            }
        }
    }

}