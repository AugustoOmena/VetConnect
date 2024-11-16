using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VetConnect.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ServiceHistory_Properties_Adjust : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceHistories_Pets_PetId",
                table: "ServiceHistories");

            migrationBuilder.AlterColumn<Guid>(
                name: "PetId",
                table: "ServiceHistories",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<int>(
                name: "ServiceType",
                table: "ServiceHistories",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceHistories_Pets_PetId",
                table: "ServiceHistories",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceHistories_Pets_PetId",
                table: "ServiceHistories");

            migrationBuilder.DropColumn(
                name: "ServiceType",
                table: "ServiceHistories");

            migrationBuilder.AlterColumn<Guid>(
                name: "PetId",
                table: "ServiceHistories",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceHistories_Pets_PetId",
                table: "ServiceHistories",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
