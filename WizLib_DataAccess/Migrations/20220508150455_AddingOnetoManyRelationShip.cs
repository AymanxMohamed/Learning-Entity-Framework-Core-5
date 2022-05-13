using Microsoft.EntityFrameworkCore.Migrations;

namespace WizLib_DataAccess.Migrations
{
    public partial class AddingOnetoManyRelationShip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_FluentPublishers_FluentPublisherPublisherId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_FluentPublisherPublisherId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "FluentPublisherPublisherId",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "FluentPublisherId",
                table: "FluentBooks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FluentBooks_FluentPublisherId",
                table: "FluentBooks",
                column: "FluentPublisherId");

            migrationBuilder.AddForeignKey(
                name: "FK_FluentBooks_FluentPublishers_FluentPublisherId",
                table: "FluentBooks",
                column: "FluentPublisherId",
                principalTable: "FluentPublishers",
                principalColumn: "PublisherId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FluentBooks_FluentPublishers_FluentPublisherId",
                table: "FluentBooks");

            migrationBuilder.DropIndex(
                name: "IX_FluentBooks_FluentPublisherId",
                table: "FluentBooks");

            migrationBuilder.DropColumn(
                name: "FluentPublisherId",
                table: "FluentBooks");

            migrationBuilder.AddColumn<int>(
                name: "FluentPublisherPublisherId",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_FluentPublisherPublisherId",
                table: "Books",
                column: "FluentPublisherPublisherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_FluentPublishers_FluentPublisherPublisherId",
                table: "Books",
                column: "FluentPublisherPublisherId",
                principalTable: "FluentPublishers",
                principalColumn: "PublisherId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
