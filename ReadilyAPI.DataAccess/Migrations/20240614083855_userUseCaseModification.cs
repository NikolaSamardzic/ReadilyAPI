using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReadilyAPI.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class userUseCaseModification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "UserUseCases");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserUseCases");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "UserUseCases");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "UserUseCases",
                newName: "Status");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "UserUseCases",
                newName: "IsActive");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "UserUseCases",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserUseCases",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "UserUseCases",
                type: "datetime2",
                nullable: true);
        }
    }
}
