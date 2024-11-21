using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace verdeconecta.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoMetasCorrecao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Metas",
                columns: table => new
                {
                    IDMe = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DaraCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    duracaoDaMeta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    metaCalorica = table.Column<float>(type: "real", nullable: false),
                    MetaFibras = table.Column<float>(type: "real", nullable: false),
                    metaProteinas = table.Column<float>(type: "real", nullable: false),
                    metaCarboidratos = table.Column<float>(type: "real", nullable: false),
                    metaSodio = table.Column<float>(type: "real", nullable: false),
                    metaGorduraTotais = table.Column<float>(type: "real", nullable: false),
                    idUsuario = table.Column<int>(type: "int", nullable: false),
                    IdNutricionista = table.Column<int>(type: "int", nullable: false),
                    idNutricionista = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Metas", x => x.IDMe);
                    table.ForeignKey(
                        name: "FK_Metas_Usuario_idNutricionista",
                        column: x => x.idNutricionista,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Metas_Usuario_idUsuario",
                        column: x => x.idUsuario,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Metas_idNutricionista",
                table: "Metas",
                column: "idNutricionista");

            migrationBuilder.CreateIndex(
                name: "IX_Metas_idUsuario",
                table: "Metas",
                column: "idUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Metas");
        }
    }
}
