﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReadilyAPI.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ReviewsTableUniqueIndexOnBookIdAndUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId_BookId",
                table: "Reviews",
                columns: new[] { "UserId", "BookId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Reviews_UserId_BookId",
                table: "Reviews");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");
        }
    }
}
