using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReportService.Migrations
{
    /// <inheritdoc />
    public partial class UpdateReportDetailsRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ReportDetails_ReportId",
                table: "ReportDetails");

            migrationBuilder.CreateIndex(
                name: "IX_ReportDetails_ReportId",
                table: "ReportDetails",
                column: "ReportId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ReportDetails_ReportId",
                table: "ReportDetails");

            migrationBuilder.CreateIndex(
                name: "IX_ReportDetails_ReportId",
                table: "ReportDetails",
                column: "ReportId",
                unique: true);
        }
    }
}
