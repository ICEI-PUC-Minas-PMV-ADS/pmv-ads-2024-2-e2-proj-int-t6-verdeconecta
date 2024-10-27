using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace verdeconecta.Migrations
{
    /// <inheritdoc />
    public partial class M02TableAlimentoseRefeicoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Refeicao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoRefeicao = table.Column<int>(type: "int", nullable: false),
                    fibras = table.Column<float>(type: "real", nullable: false),
                    proteinas = table.Column<float>(type: "real", nullable: false),
                    carboidratos = table.Column<float>(type: "real", nullable: false),
                    gorduras = table.Column<float>(type: "real", nullable: false),
                    calorias = table.Column<float>(type: "real", nullable: false),
                    DataDaRefeicao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Refeicao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Alimento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gramas = table.Column<int>(type: "int", nullable: false),
                    fibras = table.Column<float>(type: "real", nullable: false),
                    proteinas = table.Column<float>(type: "real", nullable: false),
                    carboidratos = table.Column<float>(type: "real", nullable: false),
                    gorduras = table.Column<float>(type: "real", nullable: false),
                    calorias = table.Column<float>(type: "real", nullable: false),
                    RefeicaoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alimento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alimento_Refeicao_RefeicaoId",
                        column: x => x.RefeicaoId,
                        principalTable: "Refeicao",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alimento_RefeicaoId",
                table: "Alimento",
                column: "RefeicaoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alimento");

            migrationBuilder.DropTable(
                name: "Refeicao");
        }
    }
}
