using Microsoft.EntityFrameworkCore.Migrations;

namespace WizLib_DataAccess.Migrations
{
    public partial class MakkingBOokDetailIdNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_BookDetails_BookDetailsId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_BookDetailsId",
                table: "Books");

            migrationBuilder.AlterColumn<int>(
                name: "BookDetailsId",
                table: "Books",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookDetailsId",
                table: "Books",
                column: "BookDetailsId",
                unique: true,
                filter: "[BookDetailsId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BookDetails_BookDetailsId",
                table: "Books",
                column: "BookDetailsId",
                principalTable: "BookDetails",
                principalColumn: "BookDetailId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_BookDetails_BookDetailsId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_BookDetailsId",
                table: "Books");

            migrationBuilder.AlterColumn<int>(
                name: "BookDetailsId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookDetailsId",
                table: "Books",
                column: "BookDetailsId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BookDetails_BookDetailsId",
                table: "Books",
                column: "BookDetailsId",
                principalTable: "BookDetails",
                principalColumn: "BookDetailId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
