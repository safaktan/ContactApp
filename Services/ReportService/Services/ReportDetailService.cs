using AutoMapper;
using Common.DTOs;
using Common.Models;
using ReportService.DTOs;
using ReportService.Models;
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

        public async Task<ServiceResponse<string>> SaveReportDetailAsync(ReportGeneratedDto reportGeneratedDto)
        {
            try
            {
                var reportDetailList = _mapper.Map<List<ReportDetail>>(reportGeneratedDto);
                var result = await _reportDetailRepository.SaveReportDetailAsync(reportDetailList);

                if(!result)
                {
                    return ServiceResponse<string>.Failure("Report not saved");
                }
                return ServiceResponse<string>.Success("Success");
                
            }
            catch (System.Exception ex)
            {
                return ServiceResponse<string>.Failure(ex.Message);
            }
        }
    }

}