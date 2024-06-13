using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReadilyAPI.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UseCasesesNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleCases_Roles_RoleId",
                table: "RoleCases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoleCases",
                table: "RoleCases");

            migrationBuilder.RenameTable(
                name: "RoleCases",
                newName: "RoleUseCases");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoleUseCases",
                table: "RoleUseCases",
                columns: new[] { "RoleId", "UseCaseId" });

            migrationBuilder.CreateTable(
                name: "UserUseCases",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UseCaseId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserUseCases", x => new { x.UserId, x.UseCaseId });
                    table.ForeignKey(
                        name: "FK_UserUseCases_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_RoleUseCases_Roles_RoleId",
                table: "RoleUseCases",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleUseCases_Roles_RoleId",
                table: "RoleUseCases");

            migrationBuilder.DropTable(
                name: "UserUseCases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoleUseCases",
                table: "RoleUseCases");

            migrationBuilder.RenameTable(
                name: "RoleUseCases",
                newName: "RoleCases");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoleCases",
                table: "RoleCases",
                columns: new[] { "RoleId", "UseCaseId" });

            migrationBuilder.AddForeignKey(
                name: "FK_RoleCases_Roles_RoleId",
                table: "RoleCases",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
