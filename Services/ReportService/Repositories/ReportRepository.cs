using System.Data;
using Microsoft.EntityFrameworkCore;
using ReportService.Data;
using ReportService.Models;

namespace ReportService.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly ReportDbContext _context;

        public ReportRepository(ReportDbContext context)
        {
            _context = context;
        }

        public async Task<Report> CreateReport(Report report)
        {
            await _context.Reports.AddAsync(report);
            await _context.SaveChangesAsync();
            return report;
        }

        public async Task<IEnumerable<Report>> GetAllReportsAsync()
        {
            return await _context.Reports.ToListAsync();
        }

        public async Task<Report> GetReportByIdAsync(Guid id)
        {
            return await _context.Reports.FindAsync(id);
        }

        public async Task<bool> UpdateReportStatusByIdAsync(Guid id, string status)
        {
            var report = await _context.Reports.FindAsync(id);
            
            if(report == null)
            {
                return false;
            }
            
            report.Status = status;
            var updatedRows = await _context.SaveChangesAsync();
            return updatedRows > 0;
        }
    }
}