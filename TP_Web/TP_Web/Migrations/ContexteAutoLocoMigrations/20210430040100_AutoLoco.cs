using Microsoft.EntityFrameworkCore.Migrations;

namespace TP_Web.Migrations.ContexteAutoLocoMigrations
{
    public partial class AutoLoco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Succursales",
                columns: table => new
                {
                    SuccursaleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeSuccursale = table.Column<long>(nullable: false),
                    NuméroCivique = table.Column<long>(nullable: false),
                    NomRue = table.Column<string>(nullable: false),
                    NomVille = table.Column<string>(nullable: false),
                    NomProvince = table.Column<string>(nullable: false),
                    CodePostal = table.Column<string>(nullable: false),
                    NuméroTéléphone = table.Column<string>(nullable: false)
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
                    NuméroVoiture = table.Column<long>(nullable: false),
                    Modèle = table.Column<string>(nullable: true),
                    Année = table.Column<int>(nullable: false),
                    Groupe = table.Column<int>(nullable: false),
                    Millage = table.Column<long>(nullable: false),
                    EstDisponible = table.Column<bool>(nullable: false),
                    SuccursaleId = table.Column<int>(nullable: true)
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
