using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReadilyAPI.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class PluralTableNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookCategory_Books_BookId",
                table: "BookCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_BookCategory_Categories_CategoryId",
                table: "BookCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_BookOrder_Books_BookId",
                table: "BookOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_BookOrder_Orders_OrderId",
                table: "BookOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentImage_Comments_CommentId",
                table: "CommentImage");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentImage_Images_ImagesId",
                table: "CommentImage");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCategory_Categories_CategoryId",
                table: "UserCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCategory_Users_UserId",
                table: "UserCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_Wishlist_Books_BookId",
                table: "Wishlist");

            migrationBuilder.DropForeignKey(
                name: "FK_Wishlist_Users_UserId",
                table: "Wishlist");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Wishlist",
                table: "Wishlist");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCategory",
                table: "UserCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommentImage",
                table: "CommentImage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookOrder",
                table: "BookOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookCategory",
                table: "BookCategory");

            migrationBuilder.RenameTable(
                name: "Wishlist",
                newName: "Wishlists");

            migrationBuilder.RenameTable(
                name: "UserCategory",
                newName: "UsersCategories");

            migrationBuilder.RenameTable(
                name: "CommentImage",
                newName: "CommentsImages");

            migrationBuilder.RenameTable(
                name: "BookOrder",
                newName: "BooksOrders");

            migrationBuilder.RenameTable(
                name: "BookCategory",
                newName: "BooksCategories");

            migrationBuilder.RenameIndex(
                name: "IX_Wishlist_UserId",
                table: "Wishlists",
                newName: "IX_Wishlists_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserCategory_UserId",
                table: "UsersCategories",
                newName: "IX_UsersCategories_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CommentImage_ImagesId",
                table: "CommentsImages",
                newName: "IX_CommentsImages_ImagesId");

            migrationBuilder.RenameIndex(
                name: "IX_BookOrder_OrderId",
                table: "BooksOrders",
                newName: "IX_BooksOrders_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_BookOrder_BookId",
                table: "BooksOrders",
                newName: "IX_BooksOrders_BookId");

            migrationBuilder.RenameIndex(
                name: "IX_BookCategory_CategoryId",
                table: "BooksCategories",
                newName: "IX_BooksCategories_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Wishlists",
                table: "Wishlists",
                columns: new[] { "BookId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersCategories",
                table: "UsersCategories",
                columns: new[] { "CategoryId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommentsImages",
                table: "CommentsImages",
                columns: new[] { "CommentId", "ImagesId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_BooksOrders",
                table: "BooksOrders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BooksCategories",
                table: "BooksCategories",
                columns: new[] { "BookId", "CategoryId" });

            migrationBuilder.AddForeignKey(
                name: "FK_BooksCategories_Books_BookId",
                table: "BooksCategories",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BooksCategories_Categories_CategoryId",
                table: "BooksCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BooksOrders_Books_BookId",
                table: "BooksOrders",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BooksOrders_Orders_OrderId",
                table: "BooksOrders",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CommentsImages_Comments_CommentId",
                table: "CommentsImages",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommentsImages_Images_ImagesId",
                table: "CommentsImages",
                column: "ImagesId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersCategories_Categories_CategoryId",
                table: "UsersCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersCategories_Users_UserId",
                table: "UsersCategories",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Wishlists_Books_BookId",
                table: "Wishlists",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Wishlists_Users_UserId",
                table: "Wishlists",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BooksCategories_Books_BookId",
                table: "BooksCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_BooksCategories_Categories_CategoryId",
                table: "BooksCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_BooksOrders_Books_BookId",
                table: "BooksOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_BooksOrders_Orders_OrderId",
                table: "BooksOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentsImages_Comments_CommentId",
                table: "CommentsImages");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentsImages_Images_ImagesId",
                table: "CommentsImages");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersCategories_Categories_CategoryId",
                table: "UsersCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersCategories_Users_UserId",
                table: "UsersCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_Wishlists_Books_BookId",
                table: "Wishlists");

            migrationBuilder.DropForeignKey(
                name: "FK_Wishlists_Users_UserId",
                table: "Wishlists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Wishlists",
                table: "Wishlists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersCategories",
                table: "UsersCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommentsImages",
                table: "CommentsImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BooksOrders",
                table: "BooksOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BooksCategories",
                table: "BooksCategories");

            migrationBuilder.RenameTable(
                name: "Wishlists",
                newName: "Wishlist");

            migrationBuilder.RenameTable(
                name: "UsersCategories",
                newName: "UserCategory");

            migrationBuilder.RenameTable(
                name: "CommentsImages",
                newName: "CommentImage");

            migrationBuilder.RenameTable(
                name: "BooksOrders",
                newName: "BookOrder");

            migrationBuilder.RenameTable(
                name: "BooksCategories",
                newName: "BookCategory");

            migrationBuilder.RenameIndex(
                name: "IX_Wishlists_UserId",
                table: "Wishlist",
                newName: "IX_Wishlist_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UsersCategories_UserId",
                table: "UserCategory",
                newName: "IX_UserCategory_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CommentsImages_ImagesId",
                table: "CommentImage",
                newName: "IX_CommentImage_ImagesId");

            migrationBuilder.RenameIndex(
                name: "IX_BooksOrders_OrderId",
                table: "BookOrder",
                newName: "IX_BookOrder_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_BooksOrders_BookId",
                table: "BookOrder",
                newName: "IX_BookOrder_BookId");

            migrationBuilder.RenameIndex(
                name: "IX_BooksCategories_CategoryId",
                table: "BookCategory",
                newName: "IX_BookCategory_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Wishlist",
                table: "Wishlist",
                columns: new[] { "BookId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCategory",
                table: "UserCategory",
                columns: new[] { "CategoryId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommentImage",
                table: "CommentImage",
                columns: new[] { "CommentId", "ImagesId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookOrder",
                table: "BookOrder",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookCategory",
                table: "BookCategory",
                columns: new[] { "BookId", "CategoryId" });

            migrationBuilder.AddForeignKey(
                name: "FK_BookCategory_Books_BookId",
                table: "BookCategory",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookCategory_Categories_CategoryId",
                table: "BookCategory",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookOrder_Books_BookId",
                table: "BookOrder",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookOrder_Orders_OrderId",
                table: "BookOrder",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CommentImage_Comments_CommentId",
                table: "CommentImage",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommentImage_Images_ImagesId",
                table: "CommentImage",
                column: "ImagesId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCategory_Categories_CategoryId",
                table: "UserCategory",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCategory_Users_UserId",
                table: "UserCategory",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Wishlist_Books_BookId",
                table: "Wishlist",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Wishlist_Users_UserId",
                table: "Wishlist",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
