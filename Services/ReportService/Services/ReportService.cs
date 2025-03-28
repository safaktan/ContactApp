using System.Reflection.Metadata;
using AutoMapper;
using Common.Constants;
using Common.DTOs;
using Common.Models;
using Common.RabbitMQItem;
using ReportService.DTOs;
using ReportService.Models;
using ReportService.Repositories;

namespace ReportService.Services
{
    public class ReportService : IReportService
    {
        private readonly IMapper _mapper;
        private readonly IReportRepository _reportRepository;
        private readonly IRabbitMqProducer<RabbitMqRequestDto> _rabbitMqProducer;
        public ReportService(IMapper mapper, IReportRepository reportRepository, IRabbitMqProducer<RabbitMqRequestDto> rabbitMqProducer)
        {
            _mapper = mapper;
            _reportRepository = reportRepository;
            _rabbitMqProducer = rabbitMqProducer;
        }

        public async Task<ServiceResponse<ReportDto>> CreateReport()
        {
            try
            {
                var report = new Report();
                report.RequestedDate = DateTime.UtcNow;
                var reportItem = await _reportRepository.CreateReport(report);
                var reportDtoData = _mapper.Map<ReportDto>(reportItem);
                return ServiceResponse<ReportDto>.Success(reportDtoData);
            }
            catch (System.Exception ex)
            {
                return ServiceResponse<ReportDto>.Failure(ex.Message);
            }
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

        public async Task<ServiceResponse<string>> ReportRequest(RabbitMqRequestDto rabbitMqRequestDto)
        {
            try
            {
                _rabbitMqProducer.Publish(EventNames.ReportRequested, rabbitMqRequestDto);
                return ServiceResponse<string>.Success("Report creating");
            }
            catch (System.Exception ex)
            {
                return ServiceResponse<string>.Failure(ex.Message);
            }
        }

        public async Task<ServiceResponse<string>> UpdateReportStatusByIdAsync(Guid id, string status)
        {
            try
            {
                string result = "Report status updated";
                var updatedRows = await _reportRepository.UpdateReportStatusByIdAsync(id, status);
                if(!updatedRows)
                {
                    result = "Report status not updated";
                    return ServiceResponse<string>.Failure(result);
                }

                return ServiceResponse<string>.Success(result);
            }
            catch (System.Exception ex)
            {
                return ServiceResponse<string>.Failure(ex.Message);
            }
        }
    }

}