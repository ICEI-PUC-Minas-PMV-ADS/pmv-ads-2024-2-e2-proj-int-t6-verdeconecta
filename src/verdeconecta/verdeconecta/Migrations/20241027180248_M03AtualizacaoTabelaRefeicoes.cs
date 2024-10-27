using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace verdeconecta.Migrations
{
    /// <inheritdoc />
    public partial class M03AtualizacaoTabelaRefeicoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alimento_Refeicao_RefeicaoId",
                table: "Alimento");

            migrationBuilder.RenameColumn(
                name: "proteinas",
                table: "Refeicao",
                newName: "Proteinas");

            migrationBuilder.RenameColumn(
                name: "gorduras",
                table: "Refeicao",
                newName: "Gorduras");

            migrationBuilder.RenameColumn(
                name: "fibras",
                table: "Refeicao",
                newName: "Fibras");

            migrationBuilder.RenameColumn(
                name: "carboidratos",
                table: "Refeicao",
                newName: "Carboidratos");

            migrationBuilder.RenameColumn(
                name: "calorias",
                table: "Refeicao",
                newName: "Calorias");

            migrationBuilder.RenameColumn(
                name: "RefeicaoId",
                table: "Alimento",
                newName: "AlimentoId");

            migrationBuilder.RenameIndex(
                name: "IX_Alimento_RefeicaoId",
                table: "Alimento",
                newName: "IX_Alimento_AlimentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alimento_Refeicao_AlimentoId",
                table: "Alimento",
                column: "AlimentoId",
                principalTable: "Refeicao",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alimento_Refeicao_AlimentoId",
                table: "Alimento");

            migrationBuilder.RenameColumn(
                name: "Proteinas",
                table: "Refeicao",
                newName: "proteinas");

            migrationBuilder.RenameColumn(
                name: "Gorduras",
                table: "Refeicao",
                newName: "gorduras");

            migrationBuilder.RenameColumn(
                name: "Fibras",
                table: "Refeicao",
                newName: "fibras");

            migrationBuilder.RenameColumn(
                name: "Carboidratos",
                table: "Refeicao",
                newName: "carboidratos");

            migrationBuilder.RenameColumn(
                name: "Calorias",
                table: "Refeicao",
                newName: "calorias");

            migrationBuilder.RenameColumn(
                name: "AlimentoId",
                table: "Alimento",
                newName: "RefeicaoId");

            migrationBuilder.RenameIndex(
                name: "IX_Alimento_AlimentoId",
                table: "Alimento",
                newName: "IX_Alimento_RefeicaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alimento_Refeicao_RefeicaoId",
                table: "Alimento",
                column: "RefeicaoId",
                principalTable: "Refeicao",
                principalColumn: "Id");
        }
    }
}
