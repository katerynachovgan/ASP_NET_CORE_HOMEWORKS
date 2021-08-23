using Microsoft.EntityFrameworkCore.Migrations;

namespace EF_HW.Migrations
{
    public partial class AddCountriesAllowesVaccinesManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CountriesWithAlloweds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountriesWithAlloweds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VaccineInCountries",
                columns: table => new
                {
                    AllCountriesId = table.Column<int>(type: "int", nullable: false),
                    VaccinesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccineInCountries", x => new { x.AllCountriesId, x.VaccinesId });
                    table.ForeignKey(
                        name: "FK_VaccineInCountries_CountriesWithAlloweds_AllCountriesId",
                        column: x => x.AllCountriesId,
                        principalTable: "CountriesWithAlloweds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VaccineInCountries_Vaccines_VaccinesId",
                        column: x => x.VaccinesId,
                        principalTable: "Vaccines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VaccineInCountries_VaccinesId",
                table: "VaccineInCountries",
                column: "VaccinesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VaccineInCountries");

            migrationBuilder.DropTable(
                name: "CountriesWithAlloweds");
        }
    }
}
