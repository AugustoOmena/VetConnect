using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VetConnect.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Entity_Relationship_Adjustment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scheduling_Users_UserId",
                table: "Scheduling");

            migrationBuilder.DropIndex(
                name: "IX_Scheduling_UserId",
                table: "Scheduling");

            migrationBuilder.DropColumn(
                name: "AttendenceId",
                table: "Scheduling");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Scheduling");

            migrationBuilder.DropColumn(
                name: "AppointmentId",
                table: "Attendance");

            migrationBuilder.DropColumn(
                name: "Data",
                table: "Attendance");

            migrationBuilder.AlterColumn<string>(
                name: "Prescription",
                table: "Attendance",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Attendance",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<Guid>(
                name: "AgentId",
                table: "Attendance",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AttendenceId",
                table: "Scheduling",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Scheduling",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "Prescription",
                table: "Attendance",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Attendance",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "AgentId",
                table: "Attendance",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AppointmentId",
                table: "Attendance",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Data",
                table: "Attendance",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.CreateIndex(
                name: "IX_Scheduling_UserId",
                table: "Scheduling",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Scheduling_Users_UserId",
                table: "Scheduling",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
