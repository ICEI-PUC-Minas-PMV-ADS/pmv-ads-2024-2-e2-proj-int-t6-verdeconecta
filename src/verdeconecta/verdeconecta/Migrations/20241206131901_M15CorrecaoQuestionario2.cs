using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace verdeconecta.Migrations
{
    /// <inheritdoc />
    public partial class M15CorrecaoQuestionario2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "HorarioRefeicoes",
                table: "Questionarios",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "HorarioRefeicoes",
                table: "Questionarios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
