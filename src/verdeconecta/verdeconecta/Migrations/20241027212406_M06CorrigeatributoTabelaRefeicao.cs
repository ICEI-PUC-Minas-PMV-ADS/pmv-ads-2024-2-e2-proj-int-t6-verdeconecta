using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace verdeconecta.Migrations
{
    /// <inheritdoc />
    public partial class M06CorrigeatributoTabelaRefeicao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Calorias",
                table: "Refeicao",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Carboidratos",
                table: "Refeicao",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Fibras",
                table: "Refeicao",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Gorduras",
                table: "Refeicao",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Proteinas",
                table: "Refeicao",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
