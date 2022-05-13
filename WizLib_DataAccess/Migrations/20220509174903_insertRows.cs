using Microsoft.EntityFrameworkCore.Migrations;

namespace WizLib_DataAccess.Migrations
{
    public partial class insertRows : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO tbl_Category VALUES ('seko')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
