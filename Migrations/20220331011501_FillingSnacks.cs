using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SnackMVC.Migrations
{
    public partial class FillingSnacks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Snacks(CategoryId, ShortDescription, LongDescription, InStock, ImageThumbUrl, ImageUrl, FavoriteSnack, Name, Price)" +
                "VALUES(1,'Normal Snack','Snack with hamburguer and Cheese',1,'https://cache-backend-mcd.mcdonaldscupones.com/media/image/product$kzXJhh6f/200/200/original?country=br','https://cache-backend-mcd.mcdonaldscupones.com/media/image/product$kzXJhh6f/200/200/original?country=br',1,'Cheese Salada',12.50)");
            migrationBuilder.Sql("INSERT INTO Snacks(CategoryId, ShortDescription, LongDescription, InStock, ImageThumbUrl, ImageUrl, FavoriteSnack, Name, Price)" +
                "VALUES(2,'Natural Snack','Snack with Salada and Chicken',1,'https://cache-backend-mcd.mcdonaldscupones.com/media/image/product$kUXZKLM5/200/200/original?country=br','https://cache-backend-mcd.mcdonaldscupones.com/media/image/product$kUXZKLM5/200/200/original?country=br',0,'Fit Salada',10.00)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
