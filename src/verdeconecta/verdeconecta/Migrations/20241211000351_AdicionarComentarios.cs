using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace verdeconecta.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarComentarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "Comentarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RefeicaoId = table.Column<int>(type: "int", nullable: false),
                    NutricionistaId = table.Column<int>(type: "int", nullable: false),
                    NutricionistaComment = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    NutricionistaName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comentarios_Refeicao_RefeicaoId",
                        column: x => x.RefeicaoId,
                        principalTable: "Refeicao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comentarios_Usuario_NutricionistaId",
                        column: x => x.NutricionistaId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_NutricionistaId",
                table: "Comentarios",
                column: "NutricionistaId");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_RefeicaoId",
                table: "Comentarios",
                column: "RefeicaoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comentarios");

            migrationBuilder.DropColumn(
                name: "Calorias",
                table: "Refeicao");

            migrationBuilder.DropColumn(
                name: "Carboidratos",
                table: "Refeicao");

            migrationBuilder.DropColumn(
                name: "Fibras",
                table: "Refeicao");

            migrationBuilder.DropColumn(
                name: "Gorduras",
                table: "Refeicao");

            migrationBuilder.DropColumn(
                name: "Proteinas",
                table: "Refeicao");

            migrationBuilder.AlterColumn<float>(
                name: "Quantidade",
                table: "Refeicao",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<float>(
                name: "Proteinas",
                table: "Alimento",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<float>(
                name: "Gorduras",
                table: "Alimento",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<float>(
                name: "Fibras",
                table: "Alimento",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<float>(
                name: "Carboidratos",
                table: "Alimento",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<float>(
                name: "Calorias",
                table: "Alimento",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
