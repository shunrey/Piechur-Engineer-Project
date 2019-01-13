using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JurneyTag.Migrations
{
    public partial class TabelaofertyOffertAttractios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Offerts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MaxPrice = table.Column<double>(nullable: false),
                    MinPrice = table.Column<double>(nullable: false),
                    OffertType = table.Column<string>(nullable: true),
                    Places = table.Column<int>(nullable: false),
                    CityId = table.Column<int>(nullable: false),
                    AccomodationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offerts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offerts_Accomodations_AccomodationId",
                        column: x => x.AccomodationId,
                        principalTable: "Accomodations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Offerts_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OffertAttractions",
                columns: table => new
                {
                    OffertId = table.Column<int>(nullable: false),
                    AttractionId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OffertAttractions", x => new { x.AttractionId, x.OffertId });
                    table.ForeignKey(
                        name: "FK_OffertAttractions_Attractions_AttractionId",
                        column: x => x.AttractionId,
                        principalTable: "Attractions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OffertAttractions_Offerts_OffertId",
                        column: x => x.OffertId,
                        principalTable: "Offerts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OffertAttractions_OffertId",
                table: "OffertAttractions",
                column: "OffertId");

            migrationBuilder.CreateIndex(
                name: "IX_Offerts_AccomodationId",
                table: "Offerts",
                column: "AccomodationId");

            migrationBuilder.CreateIndex(
                name: "IX_Offerts_CityId",
                table: "Offerts",
                column: "CityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OffertAttractions");

            migrationBuilder.DropTable(
                name: "Offerts");
        }
    }
}
