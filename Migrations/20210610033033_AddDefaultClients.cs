using Microsoft.EntityFrameworkCore.Migrations;

namespace Shipping_Company.Migrations
{
    public partial class AddDefaultClients : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Clients (Name,Phone,Email) VALUES ('Ahmed',01096454128,'AhmedAshraf@gmail.com')");
            migrationBuilder.Sql("INSERT INTO Clients (Name,Phone,Email) VALUES ('Mohammed',0111234,'Mohammed@gmail.com')");
            migrationBuilder.Sql("INSERT INTO Clients (Name,Phone,Email) VALUES ('Asmaa',0103456,'Asmaa@gmail.com')");
            migrationBuilder.Sql("INSERT INTO Clients (Name,Phone,Email) VALUES ('Maha',0151664,'Maha@gmail.com')");
            migrationBuilder.Sql("INSERT INTO Clients (Name,Phone,Email) VALUES ('Saad',0124234,'Saad@gmail.com')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
