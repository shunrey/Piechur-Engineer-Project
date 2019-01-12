using Microsoft.EntityFrameworkCore.Migrations;

namespace JurneyTag.Migrations
{
    public partial class UpdateAttraction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Attractions",
                newName: "TicketPrice");

            migrationBuilder.AddColumn<string>(
                name: "AddressBuild",
                table: "Attractions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddressCity",
                table: "Attractions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddressStreet",
                table: "Attractions",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "HalfTicketPrice",
                table: "Attractions",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "SeasonTime",
                table: "Attractions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressBuild",
                table: "Attractions");

            migrationBuilder.DropColumn(
                name: "AddressCity",
                table: "Attractions");

            migrationBuilder.DropColumn(
                name: "AddressStreet",
                table: "Attractions");

            migrationBuilder.DropColumn(
                name: "HalfTicketPrice",
                table: "Attractions");

            migrationBuilder.DropColumn(
                name: "SeasonTime",
                table: "Attractions");

            migrationBuilder.RenameColumn(
                name: "TicketPrice",
                table: "Attractions",
                newName: "Price");
        }
    }
}
