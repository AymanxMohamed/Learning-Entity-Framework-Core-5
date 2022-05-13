using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WizLib_DataAccess.Migrations
{
    public partial class FluentApiModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FluentPublisherPublisherId",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FluentAuthors",
                columns: table => new
                {
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FluentAuthors", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "FluentBooks",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Isbn = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    PriceRange = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookDetailsId = table.Column<int>(type: "int", nullable: false),
                    BookDetailId = table.Column<int>(type: "int", nullable: true),
                    PublisherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FluentBooks", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_FluentBooks_BookDetails_BookDetailId",
                        column: x => x.BookDetailId,
                        principalTable: "BookDetails",
                        principalColumn: "BookDetailId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FluentBooks_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publishers",
                        principalColumn: "PublisherId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FluentPublishers",
                columns: table => new
                {
                    PublisherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FluentPublishers", x => x.PublisherId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_FluentPublisherPublisherId",
                table: "Books",
                column: "FluentPublisherPublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_FluentBooks_BookDetailId",
                table: "FluentBooks",
                column: "BookDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_FluentBooks_PublisherId",
                table: "FluentBooks",
                column: "PublisherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_FluentPublishers_FluentPublisherPublisherId",
                table: "Books",
                column: "FluentPublisherPublisherId",
                principalTable: "FluentPublishers",
                principalColumn: "PublisherId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_FluentPublishers_FluentPublisherPublisherId",
                table: "Books");

            migrationBuilder.DropTable(
                name: "FluentAuthors");

            migrationBuilder.DropTable(
                name: "FluentBooks");

            migrationBuilder.DropTable(
                name: "FluentPublishers");

            migrationBuilder.DropIndex(
                name: "IX_Books_FluentPublisherPublisherId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "FluentPublisherPublisherId",
                table: "Books");
        }
    }
}
