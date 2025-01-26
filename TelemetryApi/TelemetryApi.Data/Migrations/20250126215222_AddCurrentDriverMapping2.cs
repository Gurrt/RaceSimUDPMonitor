using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TelemetryApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCurrentDriverMapping2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Driver_DriverId",
                table: "Sessions");

            migrationBuilder.DropForeignKey(
                name: "FK_Simulators_Driver_CurrentDriverId",
                table: "Simulators");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Driver",
                table: "Driver");

            migrationBuilder.RenameTable(
                name: "Driver",
                newName: "Drivers");

            migrationBuilder.RenameIndex(
                name: "IX_Driver_Name",
                table: "Drivers",
                newName: "IX_Drivers_Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Drivers",
                table: "Drivers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Drivers_DriverId",
                table: "Sessions",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Simulators_Drivers_CurrentDriverId",
                table: "Simulators",
                column: "CurrentDriverId",
                principalTable: "Drivers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Drivers_DriverId",
                table: "Sessions");

            migrationBuilder.DropForeignKey(
                name: "FK_Simulators_Drivers_CurrentDriverId",
                table: "Simulators");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Drivers",
                table: "Drivers");

            migrationBuilder.RenameTable(
                name: "Drivers",
                newName: "Driver");

            migrationBuilder.RenameIndex(
                name: "IX_Drivers_Name",
                table: "Driver",
                newName: "IX_Driver_Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Driver",
                table: "Driver",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Driver_DriverId",
                table: "Sessions",
                column: "DriverId",
                principalTable: "Driver",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Simulators_Driver_CurrentDriverId",
                table: "Simulators",
                column: "CurrentDriverId",
                principalTable: "Driver",
                principalColumn: "Id");
        }
    }
}
