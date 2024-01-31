using Microsoft.EntityFrameworkCore.Migrations;

namespace Shipping_Company.Migrations
{
    public partial class AddDefaultProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Products (Name,Price) VALUES ('Oranges',8.04)");
            migrationBuilder.Sql("INSERT INTO Products (Name,Price) VALUES ('Banana',12.70)");//Banana - 12.70
            migrationBuilder.Sql("INSERT INTO Products (Name,Price) VALUES ('Apples',24.23)");//Apples - 24.23
            migrationBuilder.Sql("INSERT INTO Products (Name,Price) VALUES ('Tomato',6.36)");// Tomato - 6.36
            migrationBuilder.Sql("INSERT INTO Products (Name,Price) VALUES ('Lettuce',4.69)");// Lettuce - 4.69
            migrationBuilder.Sql("INSERT INTO Products (Name,Price) VALUES ('Potato',6.11)");// Potato - 6.11
            migrationBuilder.Sql("INSERT INTO Products (Name,Price) VALUES ('Milk',14.79)");// Milk - 14.79
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
