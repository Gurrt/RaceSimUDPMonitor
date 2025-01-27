using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TelemetryApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarsClasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarsClasses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tracks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Location = table.Column<string>(type: "text", nullable: false),
                    Variation = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CarClassId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_CarsClasses_CarClassId",
                        column: x => x.CarClassId,
                        principalTable: "CarsClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Simulators",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    FriendlyName = table.Column<string>(type: "text", nullable: false),
                    NumSessions = table.Column<long>(type: "bigint", nullable: false),
                    CurrentDriverId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Simulators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Simulators_Drivers_CurrentDriverId",
                        column: x => x.CurrentDriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DriverId = table.Column<int>(type: "integer", nullable: false),
                    SimulatorId = table.Column<string>(type: "text", nullable: false),
                    TrackId = table.Column<int>(type: "integer", nullable: false),
                    CarId = table.Column<int>(type: "integer", nullable: false),
                    StartedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    EndedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sessions_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sessions_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sessions_Simulators_SimulatorId",
                        column: x => x.SimulatorId,
                        principalTable: "Simulators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sessions_Tracks_TrackId",
                        column: x => x.TrackId,
                        principalTable: "Tracks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Laps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SessionId = table.Column<int>(type: "integer", nullable: false),
                    CompletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Number = table.Column<int>(type: "integer", nullable: false),
                    TotalTime = table.Column<float>(type: "real", nullable: false),
                    Sector1Time = table.Column<float>(type: "real", nullable: false),
                    Sector2Time = table.Column<float>(type: "real", nullable: false),
                    Sector3Time = table.Column<float>(type: "real", nullable: false),
                    Valid = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Laps_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CarClassId",
                table: "Cars",
                column: "CarClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_Name",
                table: "Cars",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarsClasses_Name",
                table: "CarsClasses",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_Name",
                table: "Drivers",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Laps_SessionId",
                table: "Laps",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_CarId",
                table: "Sessions",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_DriverId",
                table: "Sessions",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_SimulatorId",
                table: "Sessions",
                column: "SimulatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_TrackId",
                table: "Sessions",
                column: "TrackId");

            migrationBuilder.CreateIndex(
                name: "IX_Simulators_CurrentDriverId",
                table: "Simulators",
                column: "CurrentDriverId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Laps");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Simulators");

            migrationBuilder.DropTable(
                name: "Tracks");

            migrationBuilder.DropTable(
                name: "CarsClasses");

            migrationBuilder.DropTable(
                name: "Drivers");
        }
    }
}
