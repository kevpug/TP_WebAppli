using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TP_Web.Migrations.ContexteAutoLocoMigrations
{
    public partial class AutoLoco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NuméroPermisConduire = table.Column<string>(nullable: true),
                    Prénom = table.Column<string>(nullable: true),
                    Nom = table.Column<string>(nullable: true),
                    NuméroTéléphone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientId);
                });

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
                    NuméroVoiture = table.Column<long>(nullable: true),
                    Modèle = table.Column<string>(nullable: true),
                    Année = table.Column<int>(nullable: true),
                    Groupe = table.Column<int>(nullable: true),
                    Millage = table.Column<long>(nullable: true),
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

            migrationBuilder.CreateTable(
                name: "DossierAccidents",
                columns: table => new
                {
                    DossierID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RapportAccident = table.Column<string>(nullable: true),
                    DossierFermé = table.Column<bool>(nullable: false),
                    ClientId = table.Column<long>(nullable: true),
                    VoitureId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DossierAccidents", x => x.DossierID);
                    table.ForeignKey(
                        name: "FK_DossierAccidents_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DossierAccidents_Voitures_VoitureId",
                        column: x => x.VoitureId,
                        principalTable: "Voitures",
                        principalColumn: "VoitureId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreJoursLocation = table.Column<int>(nullable: false),
                    DateDeLocation = table.Column<DateTime>(nullable: false),
                    SuccursaleDeRetourSuccursaleId = table.Column<int>(nullable: true),
                    VoitureId = table.Column<long>(nullable: true),
                    ClientId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationId);
                    table.ForeignKey(
                        name: "FK_Locations_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Locations_Succursales_SuccursaleDeRetourSuccursaleId",
                        column: x => x.SuccursaleDeRetourSuccursaleId,
                        principalTable: "Succursales",
                        principalColumn: "SuccursaleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Locations_Voitures_VoitureId",
                        column: x => x.VoitureId,
                        principalTable: "Voitures",
                        principalColumn: "VoitureId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DossierAccidents_ClientId",
                table: "DossierAccidents",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_DossierAccidents_VoitureId",
                table: "DossierAccidents",
                column: "VoitureId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_ClientId",
                table: "Locations",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_SuccursaleDeRetourSuccursaleId",
                table: "Locations",
                column: "SuccursaleDeRetourSuccursaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_VoitureId",
                table: "Locations",
                column: "VoitureId");

            migrationBuilder.CreateIndex(
                name: "IX_Voitures_SuccursaleId",
                table: "Voitures",
                column: "SuccursaleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DossierAccidents");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Voitures");

            migrationBuilder.DropTable(
                name: "Succursales");
        }
    }
}
