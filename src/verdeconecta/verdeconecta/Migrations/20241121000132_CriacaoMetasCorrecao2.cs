using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace verdeconecta.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoMetasCorrecao2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Metas_Usuario_idNutricionista",
                table: "Metas");

            migrationBuilder.DropColumn(
                name: "IdNutricionista",
                table: "Metas");

            migrationBuilder.RenameColumn(
                name: "idNutricionista",
                table: "Metas",
                newName: "IdNutricionista");

            migrationBuilder.RenameIndex(
                name: "IX_Metas_idNutricionista",
                table: "Metas",
                newName: "IX_Metas_IdNutricionista");

            migrationBuilder.AlterColumn<int>(
                name: "IdNutricionista",
                table: "Metas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Metas_Usuario_IdNutricionista",
                table: "Metas",
                column: "IdNutricionista",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Metas_Usuario_IdNutricionista",
                table: "Metas");

            migrationBuilder.RenameColumn(
                name: "IdNutricionista",
                table: "Metas",
                newName: "idNutricionista");

            migrationBuilder.RenameIndex(
                name: "IX_Metas_IdNutricionista",
                table: "Metas",
                newName: "IX_Metas_idNutricionista");

            migrationBuilder.AlterColumn<int>(
                name: "idNutricionista",
                table: "Metas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "IdNutricionista",
                table: "Metas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Metas_Usuario_idNutricionista",
                table: "Metas",
                column: "idNutricionista",
                principalTable: "Usuario",
                principalColumn: "Id");
        }
    }
}
