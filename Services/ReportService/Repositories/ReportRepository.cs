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
        public async Task<IEnumerable<Report>> GetAllReportsAsync()
        {
            return await _context.Reports.ToListAsync();
        }
    }
}