using Microsoft.EntityFrameworkCore.Migrations;

namespace WizLib_DataAccess.Migrations
{
    public partial class AddingManyToManyRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FluentBookAuthor",
                columns: table => new
                {
                    FluentBookId = table.Column<int>(type: "int", nullable: false),
                    FluentAuthorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FluentBookAuthor", x => new { x.FluentBookId, x.FluentAuthorId });
                    table.ForeignKey(
                        name: "FK_FluentBookAuthor_FluentAuthors_FluentAuthorId",
                        column: x => x.FluentAuthorId,
                        principalTable: "FluentAuthors",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FluentBookAuthor_FluentBooks_FluentBookId",
                        column: x => x.FluentBookId,
                        principalTable: "FluentBooks",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FluentBookAuthor_FluentAuthorId",
                table: "FluentBookAuthor",
                column: "FluentAuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FluentBookAuthor");
        }
    }
}
