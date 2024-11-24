using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace verdeconecta.Migrations
{
    /// <inheritdoc />
    public partial class M12Addrelacaousuarioquestionario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Questionarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoDieta = table.Column<int>(type: "int", nullable: true),
                    TemRestricaoAlimentar = table.Column<bool>(type: "bit", nullable: false),
                    RestricaoDetalhes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NivelAtividadeFisica = table.Column<int>(type: "int", nullable: false),
                    ObjetivoPrincipal = table.Column<int>(type: "int", nullable: false),
                    RefeicoesPorDia = table.Column<int>(type: "int", nullable: false),
                    HorarioRefeicoes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConsumoFrutasVegetais = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questionarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questionarios_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Questionarios_UsuarioId",
                table: "Questionarios",
                column: "UsuarioId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Questionarios");
        }
    }
}
