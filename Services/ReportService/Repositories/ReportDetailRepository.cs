using Microsoft.EntityFrameworkCore;
using ReportService.Data;
using ReportService.Models;

namespace ReportService.Repositories
{
    public class ReportDetailRepository : IReportDetailRepository
    {
        private readonly ReportDbContext _context;

        public ReportDetailRepository(ReportDbContext context)
        {
            _context = context;   
        }
        public async Task<ReportDetail> GetReportDetailByReportIdAsync(Guid reportId)
        {
            return await _context.ReportDetails.FirstOrDefaultAsync(x => x.ReportId == reportId);
        }

        public async Task<bool> SaveReportDetailAsync(List<ReportDetail> reportDetailList)
        {
            await _context.ReportDetails.AddRangeAsync(reportDetailList);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}