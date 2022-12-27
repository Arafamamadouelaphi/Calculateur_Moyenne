using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalculateurEF.Migrations
{
    /// <inheritdoc />
    public partial class Migrationcalcule : Migration
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
                name: "Bloc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(type: "TEXT", nullable: false),
                    MoyenneBloc = table.Column<string>(type: "TEXT", nullable: false),
                    IDMaquetteFrk = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bloc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bloc_Maquettes_IDMaquetteFrk",
                        column: x => x.IDMaquetteFrk,
                        principalTable: "Maquettes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ue",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Coefficient = table.Column<int>(type: "INTEGER", nullable: false),
                    moyenneUe = table.Column<double>(type: "REAL", nullable: false),
                    intitulé = table.Column<string>(type: "TEXT", nullable: false),
                    IDForeignKey = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ue_Bloc_IDForeignKey",
                        column: x => x.IDForeignKey,
                        principalTable: "Bloc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "matier",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nommatiere = table.Column<string>(type: "TEXT", nullable: false),
                    Note = table.Column<int>(type: "INTEGER", nullable: false),
                    Coef = table.Column<int>(type: "INTEGER", nullable: false),
                    IDUEForeignKey = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_matier", x => x.Id);
                    table.ForeignKey(
                        name: "FK_matier_Ue_IDUEForeignKey",
                        column: x => x.IDUEForeignKey,
                        principalTable: "Ue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bloc_IDMaquetteFrk",
                table: "Bloc",
                column: "IDMaquetteFrk");

            migrationBuilder.CreateIndex(
                name: "IX_matier_IDUEForeignKey",
                table: "matier",
                column: "IDUEForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_Ue_IDForeignKey",
                table: "Ue",
                column: "IDForeignKey");
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
