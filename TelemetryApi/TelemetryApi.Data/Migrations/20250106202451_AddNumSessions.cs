using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TelemetryApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddNumSessions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "NumSessions",
                table: "Simulators",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumSessions",
                table: "Simulators");
        }
    }
}
