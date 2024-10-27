using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace verdeconecta.Migrations
{
    /// <inheritdoc />
    public partial class M05TableAlimentosRefeicoesUsuarioForeingKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alimento_Refeicao_AlimentoId",
                table: "Alimento");

            migrationBuilder.DropIndex(
                name: "IX_Alimento_AlimentoId",
                table: "Alimento");

            migrationBuilder.DropColumn(
                name: "AlimentoId",
                table: "Alimento");

            migrationBuilder.RenameColumn(
                name: "proteinas",
                table: "Alimento",
                newName: "Proteinas");

            migrationBuilder.RenameColumn(
                name: "gramas",
                table: "Alimento",
                newName: "Gramas");

            migrationBuilder.RenameColumn(
                name: "gorduras",
                table: "Alimento",
                newName: "Gorduras");

            migrationBuilder.RenameColumn(
                name: "fibras",
                table: "Alimento",
                newName: "Fibras");

            migrationBuilder.RenameColumn(
                name: "carboidratos",
                table: "Alimento",
                newName: "Carboidratos");

            migrationBuilder.RenameColumn(
                name: "calorias",
                table: "Alimento",
                newName: "Calorias");

            migrationBuilder.AddColumn<int>(
                name: "AlimentoId",
                table: "Refeicao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Refeicao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Refeicao_AlimentoId",
                table: "Refeicao",
                column: "AlimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Refeicao_UsuarioId",
                table: "Refeicao",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Refeicao_Alimento_AlimentoId",
                table: "Refeicao",
                column: "AlimentoId",
                principalTable: "Alimento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Refeicao_Usuario_UsuarioId",
                table: "Refeicao",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Refeicao_Alimento_AlimentoId",
                table: "Refeicao");

            migrationBuilder.DropForeignKey(
                name: "FK_Refeicao_Usuario_UsuarioId",
                table: "Refeicao");

            migrationBuilder.DropIndex(
                name: "IX_Refeicao_AlimentoId",
                table: "Refeicao");

            migrationBuilder.DropIndex(
                name: "IX_Refeicao_UsuarioId",
                table: "Refeicao");

            migrationBuilder.DropColumn(
                name: "AlimentoId",
                table: "Refeicao");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Refeicao");

            migrationBuilder.RenameColumn(
                name: "Proteinas",
                table: "Alimento",
                newName: "proteinas");

            migrationBuilder.RenameColumn(
                name: "Gramas",
                table: "Alimento",
                newName: "gramas");

            migrationBuilder.RenameColumn(
                name: "Gorduras",
                table: "Alimento",
                newName: "gorduras");

            migrationBuilder.RenameColumn(
                name: "Fibras",
                table: "Alimento",
                newName: "fibras");

            migrationBuilder.RenameColumn(
                name: "Carboidratos",
                table: "Alimento",
                newName: "carboidratos");

            migrationBuilder.RenameColumn(
                name: "Calorias",
                table: "Alimento",
                newName: "calorias");

            migrationBuilder.AddColumn<int>(
                name: "AlimentoId",
                table: "Alimento",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Alimento_AlimentoId",
                table: "Alimento",
                column: "AlimentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alimento_Refeicao_AlimentoId",
                table: "Alimento",
                column: "AlimentoId",
                principalTable: "Refeicao",
                principalColumn: "Id");
        }
    }
}
