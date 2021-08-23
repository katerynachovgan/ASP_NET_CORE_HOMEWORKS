using Microsoft.EntityFrameworkCore.Migrations;

namespace EF_HW.Migrations
{
    public partial class AddDiseasesClassAndManyWithOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DiseaseId",
                table: "Vaccines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Diseases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diseases", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vaccines_DiseaseId",
                table: "Vaccines",
                column: "DiseaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vaccines_Diseases_DiseaseId",
                table: "Vaccines",
                column: "DiseaseId",
                principalTable: "Diseases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vaccines_Diseases_DiseaseId",
                table: "Vaccines");

            migrationBuilder.DropTable(
                name: "Diseases");

            migrationBuilder.DropIndex(
                name: "IX_Vaccines_DiseaseId",
                table: "Vaccines");

            migrationBuilder.DropColumn(
                name: "DiseaseId",
                table: "Vaccines");
        }
    }
}
