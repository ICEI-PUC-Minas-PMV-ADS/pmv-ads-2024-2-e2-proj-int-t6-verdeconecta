using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace verdeconecta.Migrations
{
    /// <inheritdoc />
    public partial class M11TabelaRelacionamentoNutricionistaCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RelacionamentoNutricionistaCliente",
                columns: table => new
                {
                    IdNutricionista = table.Column<int>(type: "int", nullable: false),
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelacionamentoNutricionistaCliente", x => new { x.IdNutricionista, x.IdCliente });
                    table.ForeignKey(
                        name: "FK_RelacionamentoNutricionistaCliente_Usuario_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RelacionamentoNutricionistaCliente_Usuario_IdNutricionista",
                        column: x => x.IdNutricionista,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RelacionamentoNutricionistaCliente_IdCliente",
                table: "RelacionamentoNutricionistaCliente",
                column: "IdCliente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RelacionamentoNutricionistaCliente");
        }
    }
}
