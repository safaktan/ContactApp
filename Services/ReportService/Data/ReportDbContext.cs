using Microsoft.EntityFrameworkCore;
using ReportService.Models;

namespace ReportService.Data
{
    public class ReportDbContext : DbContext
    {
        public ReportDbContext(DbContextOptions<ReportDbContext> options) : base(options)
        {
        }

        public DbSet<Report> Reports { get; set; }
        public DbSet<ReportDetail> ReportDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Report>()
                .HasOne(r => r.ReportDetail)
                .WithOne(rd => rd.Report)
                .HasForeignKey<ReportDetail>(rd => rd.ReportId)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }

}