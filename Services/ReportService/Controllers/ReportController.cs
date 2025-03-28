using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Common.Constants;
using Common.DTOs;
using Common.RabbitMQItem;
using Microsoft.AspNetCore.Mvc;
using ReportService.DTOs;
using ReportService.Repositories;
using ReportService.Services;

namespace ReportService.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;
        private readonly IReportDetailService _reportDetailService;


        public ReportController(IReportService reportService, IReportDetailService reportDetailService)
        {
            _reportService = reportService;
            _reportDetailService = reportDetailService;
        }

        [HttpGet("GetAllReports")]
        public async Task<IActionResult> GetAllReports()
        {
            var response = await _reportService.GetAllReportsAsync();

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("GetReportDetailByReportId/{reportId}")]
        public async Task<IActionResult> GetReportDetailByReportId(Guid reportId)
        {
            var response = await _reportDetailService.GetReportDetailByReportIdAsync(reportId);

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPost("RequestReport")]
        public async Task<IActionResult> RequestReport()
        {
            var createReportResponse = await _reportService.CreateReport();
            if(!createReportResponse.IsSuccess)
            {
                return BadRequest(Response);
            }

            var rabbitMqRequestDto = new RabbitMqRequestDto();
            rabbitMqRequestDto.ReportId = createReportResponse.Data.Id;
            var response = await _reportService.ReportRequest(rabbitMqRequestDto);
            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}