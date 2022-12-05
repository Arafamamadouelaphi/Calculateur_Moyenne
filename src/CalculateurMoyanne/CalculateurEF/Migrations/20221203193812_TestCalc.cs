using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalculateurEF.Migrations
{
    /// <inheritdoc />
    public partial class TestCalc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Maquettes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomMaquette = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maquettes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ue",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Coefficient = table.Column<int>(type: "INTEGER", nullable: false),
                    intitulé = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ue", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bloc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(type: "TEXT", nullable: false),
                    MaquetteEntityId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bloc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bloc_Maquettes_MaquetteEntityId",
                        column: x => x.MaquetteEntityId,
                        principalTable: "Maquettes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "matier",
                columns: table => new
                {
                    id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nommatiere = table.Column<string>(type: "TEXT", nullable: false),
                    Note = table.Column<int>(type: "INTEGER", nullable: false),
                    Coef = table.Column<int>(type: "INTEGER", nullable: false),
                    UEentityId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_matier", x => x.id);
                    table.ForeignKey(
                        name: "FK_matier_Ue_UEentityId",
                        column: x => x.UEentityId,
                        principalTable: "Ue",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bloc_MaquetteEntityId",
                table: "Bloc",
                column: "MaquetteEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_matier_UEentityId",
                table: "matier",
                column: "UEentityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bloc");

            migrationBuilder.DropTable(
                name: "matier");

            migrationBuilder.DropTable(
                name: "Maquettes");

            migrationBuilder.DropTable(
                name: "Ue");
        }
    }
}
