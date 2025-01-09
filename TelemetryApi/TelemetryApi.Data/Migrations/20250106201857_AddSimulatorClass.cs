using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TelemetryApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSimulatorClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Simulators",
                columns: table => new
                {
                    Identifier = table.Column<string>(type: "text", nullable: false),
                    FriendlyName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Simulators", x => x.Identifier);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Simulators");
        }
    }
}
