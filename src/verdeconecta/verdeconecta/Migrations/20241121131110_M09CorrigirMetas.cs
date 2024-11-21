using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace verdeconecta.Migrations
{
    /// <inheritdoc />
    public partial class M09CorrigirMetas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "Meta",
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
                    idUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meta", x => x.IDMe);
                    table.ForeignKey(
                        name: "FK_Meta_Usuario_idUsuario",
                        column: x => x.idUsuario,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Meta_idUsuario",
                table: "Meta",
                column: "idUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Meta");

        }
    }
}
