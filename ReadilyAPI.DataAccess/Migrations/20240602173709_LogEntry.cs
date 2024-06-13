using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReadilyAPI.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class LogEntry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ErrorLog",
                table: "ErrorLog");

            migrationBuilder.RenameTable(
                name: "ErrorLog",
                newName: "ErrorLogs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ErrorLogs",
                table: "ErrorLogs",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "LogEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Actor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActorId = table.Column<int>(type: "int", nullable: false),
                    UseCaseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UseCaseData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogEntries", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogEntries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ErrorLogs",
                table: "ErrorLogs");

            migrationBuilder.RenameTable(
                name: "ErrorLogs",
                newName: "ErrorLog");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ErrorLog",
                table: "ErrorLog",
                column: "Id");
        }
    }
}
