using Microsoft.EntityFrameworkCore.Migrations;

namespace WizLib_DataAccess.Migrations
{
    public partial class AddingOnetoOneRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FluentBooks_BookDetails_BookDetailId",
                table: "FluentBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_FluentBooks_Publishers_PublisherId",
                table: "FluentBooks");

            migrationBuilder.DropIndex(
                name: "IX_FluentBooks_BookDetailId",
                table: "FluentBooks");

            migrationBuilder.DropIndex(
                name: "IX_FluentBooks_PublisherId",
                table: "FluentBooks");

            migrationBuilder.DropColumn(
                name: "BookDetailId",
                table: "FluentBooks");

            migrationBuilder.DropColumn(
                name: "BookDetailsId",
                table: "FluentBooks");

            migrationBuilder.RenameColumn(
                name: "PublisherId",
                table: "FluentBooks",
                newName: "FluentBookDetailId");

            migrationBuilder.CreateTable(
                name: "tbl_Category",
                columns: table => new
                {
                    Category_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Category", x => x.Category_Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FluentBooks_FluentBookDetailId",
                table: "FluentBooks",
                column: "FluentBookDetailId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FluentBooks_FluentBookDetails_FluentBookDetailId",
                table: "FluentBooks",
                column: "FluentBookDetailId",
                principalTable: "FluentBookDetails",
                principalColumn: "BookDetailId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FluentBooks_FluentBookDetails_FluentBookDetailId",
                table: "FluentBooks");

            migrationBuilder.DropTable(
                name: "tbl_Category");

            migrationBuilder.DropIndex(
                name: "IX_FluentBooks_FluentBookDetailId",
                table: "FluentBooks");

            migrationBuilder.RenameColumn(
                name: "FluentBookDetailId",
                table: "FluentBooks",
                newName: "PublisherId");

            migrationBuilder.AddColumn<int>(
                name: "BookDetailId",
                table: "FluentBooks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BookDetailsId",
                table: "FluentBooks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FluentBooks_BookDetailId",
                table: "FluentBooks",
                column: "BookDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_FluentBooks_PublisherId",
                table: "FluentBooks",
                column: "PublisherId");

            migrationBuilder.AddForeignKey(
                name: "FK_FluentBooks_BookDetails_BookDetailId",
                table: "FluentBooks",
                column: "BookDetailId",
                principalTable: "BookDetails",
                principalColumn: "BookDetailId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FluentBooks_Publishers_PublisherId",
                table: "FluentBooks",
                column: "PublisherId",
                principalTable: "Publishers",
                principalColumn: "PublisherId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
