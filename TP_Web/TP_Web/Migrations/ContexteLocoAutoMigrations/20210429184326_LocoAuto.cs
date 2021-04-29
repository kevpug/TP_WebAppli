using Microsoft.EntityFrameworkCore.Migrations;

namespace TP_Web.Migrations.ContexteLocoAutoMigrations
{
    public partial class LocoAuto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Succursales",
                columns: table => new
                {
                    SuccursaleId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NuméroCivique = table.Column<long>(nullable: false),
                    NomRue = table.Column<string>(nullable: true),
                    NomVille = table.Column<string>(nullable: true),
                    NomProvince = table.Column<string>(nullable: true),
                    CodePostal = table.Column<string>(nullable: true),
                    NuméroTéléphone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Succursales", x => x.SuccursaleId);
                });

            migrationBuilder.CreateTable(
                name: "Voitures",
                columns: table => new
                {
                    VoitureId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Modèle = table.Column<string>(nullable: true),
                    Année = table.Column<int>(nullable: false),
                    Groupe = table.Column<int>(nullable: false),
                    Millage = table.Column<long>(nullable: false),
                    SuccursaleId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voitures", x => x.VoitureId);
                    table.ForeignKey(
                        name: "FK_Voitures_Succursales_SuccursaleId",
                        column: x => x.SuccursaleId,
                        principalTable: "Succursales",
                        principalColumn: "SuccursaleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Voitures_SuccursaleId",
                table: "Voitures",
                column: "SuccursaleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Voitures");

            migrationBuilder.DropTable(
                name: "Succursales");
        }
    }
}
