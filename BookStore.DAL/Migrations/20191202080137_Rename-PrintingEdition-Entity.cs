using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.DAL.Migrations
{
    public partial class RenamePrintingEditionEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorBooks_PrintingEditions_PrintingEditionId",
                table: "AuthorBooks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PrintingEditions",
                table: "PrintingEditions");

            migrationBuilder.RenameTable(
                name: "PrintingEditions",
                newName: "Books");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books",
                table: "Books",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorBooks_Books_PrintingEditionId",
                table: "AuthorBooks",
                column: "PrintingEditionId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorBooks_Books_PrintingEditionId",
                table: "AuthorBooks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Books",
                table: "Books");

            migrationBuilder.RenameTable(
                name: "Books",
                newName: "PrintingEditions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PrintingEditions",
                table: "PrintingEditions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorBooks_PrintingEditions_PrintingEditionId",
                table: "AuthorBooks",
                column: "PrintingEditionId",
                principalTable: "PrintingEditions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
