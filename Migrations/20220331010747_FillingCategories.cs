using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SnackMVC.Migrations
{
    public partial class FillingCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categories(CategoryName, Description)" +
                "VALUES('Normal','Standard Snack')");

            migrationBuilder.Sql("INSERT INTO Categories(CategoryName, Description)" +
                "VALUES('Natural','Fit Snack')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
