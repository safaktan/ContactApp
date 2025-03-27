using AutoMapper;
using Common.Models;
using ReportService.DTOs;
using ReportService.Repositories;

namespace ReportService.Services
{
    public class ReportService : IReportService
    {
        private readonly IMapper _mapper;
        private readonly IReportRepository _reportRepository;
        public ReportService(IMapper mapper, IReportRepository reportRepository)
        {
            _mapper = mapper;
            _reportRepository = reportRepository;
        }
        public async Task<ServiceResponse<IEnumerable<ReportDto>>> GetAllReportsAsync()
        {
            try
            {
                var reports = await _reportRepository.GetAllReportsAsync();
                var reportList = _mapper.Map<IEnumerable<ReportDto>>(reports);
                return ServiceResponse<IEnumerable<ReportDto>>.Success(reportList);
            }
            catch (System.Exception ex)
            {
                return ServiceResponse<IEnumerable<ReportDto>>.Failure(ex.Message);
            }
        }
    }

}