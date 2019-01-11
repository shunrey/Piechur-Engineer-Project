using Microsoft.EntityFrameworkCore.Migrations;

namespace JurneyTag.Migrations
{
    public partial class Dodanobrakującekolumny : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AddressBuild",
                table: "Accomodations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddressCity",
                table: "Accomodations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddressStreet",
                table: "Accomodations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressBuild",
                table: "Accomodations");

            migrationBuilder.DropColumn(
                name: "AddressCity",
                table: "Accomodations");

            migrationBuilder.DropColumn(
                name: "AddressStreet",
                table: "Accomodations");
        }
    }
}
