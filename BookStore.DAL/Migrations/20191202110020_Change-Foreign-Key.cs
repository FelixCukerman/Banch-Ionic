using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.DAL.Migrations
{
    public partial class ChangeForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorBooks_Books_PrintingEditionId",
                table: "AuthorBooks");

            migrationBuilder.RenameColumn(
                name: "PrintingEditionId",
                table: "AuthorBooks",
                newName: "BookId");

            migrationBuilder.RenameIndex(
                name: "IX_AuthorBooks_PrintingEditionId",
                table: "AuthorBooks",
                newName: "IX_AuthorBooks_BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorBooks_Books_BookId",
                table: "AuthorBooks",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorBooks_Books_BookId",
                table: "AuthorBooks");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "AuthorBooks",
                newName: "PrintingEditionId");

            migrationBuilder.RenameIndex(
                name: "IX_AuthorBooks_BookId",
                table: "AuthorBooks",
                newName: "IX_AuthorBooks_PrintingEditionId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorBooks_Books_PrintingEditionId",
                table: "AuthorBooks",
                column: "PrintingEditionId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
