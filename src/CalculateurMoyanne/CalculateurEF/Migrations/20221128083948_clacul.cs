using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalculateurEF.Migrations
{
    /// <inheritdoc />
    public partial class clacul : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Maquettes",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomMaquette = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maquettes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Bloc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(type: "TEXT", nullable: false),
                    MaquetteEntityid = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bloc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bloc_Maquettes_MaquetteEntityid",
                        column: x => x.MaquetteEntityid,
                        principalTable: "Maquettes",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Ue",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Coefficient = table.Column<int>(type: "INTEGER", nullable: false),
                    intitulé = table.Column<string>(type: "TEXT", nullable: false),
                    BlocEntityId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ue_Bloc_BlocEntityId",
                        column: x => x.BlocEntityId,
                        principalTable: "Bloc",
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
                name: "IX_Bloc_MaquetteEntityid",
                table: "Bloc",
                column: "MaquetteEntityid");

            migrationBuilder.CreateIndex(
                name: "IX_matier_UEentityId",
                table: "matier",
                column: "UEentityId");

            migrationBuilder.CreateIndex(
                name: "IX_Ue_BlocEntityId",
                table: "Ue",
                column: "BlocEntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "matier");

            migrationBuilder.DropTable(
                name: "Ue");

            migrationBuilder.DropTable(
                name: "Bloc");

            migrationBuilder.DropTable(
                name: "Maquettes");
        }
    }
}
