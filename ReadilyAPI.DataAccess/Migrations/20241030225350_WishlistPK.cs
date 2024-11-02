using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReadilyAPI.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class WishlistPK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Wishlists",
                table: "Wishlists");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Wishlists",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Wishlists",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Wishlists",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Wishlists",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Wishlists",
                table: "Wishlists",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Wishlists_BookId",
                table: "Wishlists",
                column: "BookId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Wishlists",
                table: "Wishlists");

            migrationBuilder.DropIndex(
                name: "IX_Wishlists_BookId",
                table: "Wishlists");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Wishlists");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Wishlists");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Wishlists");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Wishlists");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Wishlists",
                table: "Wishlists",
                columns: new[] { "BookId", "UserId" });
        }
    }
}
