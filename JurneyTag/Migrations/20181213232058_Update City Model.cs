using Microsoft.EntityFrameworkCore.Migrations;

namespace JurneyTag.Migrations
{
    public partial class UpdateCityModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Area",
                table: "Cities",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "MetersAboveSeaLevel",
                table: "Cities",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Population",
                table: "Cities",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "PopulationDensity",
                table: "Cities",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Area",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "MetersAboveSeaLevel",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "Population",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "PopulationDensity",
                table: "Cities");
        }
    }
}
