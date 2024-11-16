using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VetConnect.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ServiceHistory_Relation_Adjust : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceHistories_Scheduling_SchedulingId",
                table: "ServiceHistories");

            migrationBuilder.DropTable(
                name: "Attendance");

            migrationBuilder.DropTable(
                name: "Scheduling");

            migrationBuilder.DropIndex(
                name: "IX_ServiceHistories_SchedulingId",
                table: "ServiceHistories");

            migrationBuilder.DropColumn(
                name: "SchedulingId",
                table: "ServiceHistories");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SchedulingId",
                table: "ServiceHistories",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Scheduling",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PetId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateDeleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DateEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateInitial = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUppdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: false),
                    ServiceId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scheduling", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Scheduling_Pets_PetId",
                        column: x => x.PetId,
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attendance",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SchedulingId = table.Column<Guid>(type: "uuid", nullable: false),
                    AgentId = table.Column<Guid>(type: "uuid", nullable: true),
                    AttendanceStatus = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateDeleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DateUppdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Prescription = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attendance_Scheduling_SchedulingId",
                        column: x => x.SchedulingId,
                        principalTable: "Scheduling",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceHistories_SchedulingId",
                table: "ServiceHistories",
                column: "SchedulingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_SchedulingId",
                table: "Attendance",
                column: "SchedulingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Scheduling_PetId",
                table: "Scheduling",
                column: "PetId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceHistories_Scheduling_SchedulingId",
                table: "ServiceHistories",
                column: "SchedulingId",
                principalTable: "Scheduling",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
