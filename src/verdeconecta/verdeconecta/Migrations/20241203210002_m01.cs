using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace verdeconecta.Migrations
{
    /// <inheritdoc />
    public partial class m01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alimento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fibras = table.Column<double>(type: "float", nullable: false),
                    Proteinas = table.Column<double>(type: "float", nullable: false),
                    Carboidratos = table.Column<double>(type: "float", nullable: false),
                    Gorduras = table.Column<double>(type: "float", nullable: false),
                    Calorias = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alimento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DicasNutricionais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dica = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataDica = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Likes = table.Column<int>(type: "int", nullable: false),
                    Dislikes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DicasNutricionais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataDeNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Peso = table.Column<float>(type: "real", nullable: false),
                    Altura = table.Column<float>(type: "real", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Perfil = table.Column<int>(type: "int", nullable: false),
                    TokenRedefinicaoSenha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TokenValidade = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "Refeicao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoRefeicao = table.Column<int>(type: "int", nullable: false),
                    DataDaRefeicao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantidade = table.Column<double>(type: "float", nullable: false),
                    Fibras = table.Column<double>(type: "float", nullable: false),
                    Proteinas = table.Column<double>(type: "float", nullable: false),
                    Carboidratos = table.Column<double>(type: "float", nullable: false),
                    Gorduras = table.Column<double>(type: "float", nullable: false),
                    Calorias = table.Column<double>(type: "float", nullable: false),
                    AlimentoId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Refeicao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Refeicao_Alimento_AlimentoId",
                        column: x => x.AlimentoId,
                        principalTable: "Alimento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Refeicao_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_Meta_idUsuario",
                table: "Meta",
                column: "idUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Questionarios_UsuarioId",
                table: "Questionarios",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Refeicao_AlimentoId",
                table: "Refeicao",
                column: "AlimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Refeicao_UsuarioId",
                table: "Refeicao",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_RelacionamentoNutricionistaCliente_IdCliente",
                table: "RelacionamentoNutricionistaCliente",
                column: "IdCliente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DicasNutricionais");

            migrationBuilder.DropTable(
                name: "Meta");

            migrationBuilder.DropTable(
                name: "Questionarios");

            migrationBuilder.DropTable(
                name: "Refeicao");

            migrationBuilder.DropTable(
                name: "RelacionamentoNutricionistaCliente");

            migrationBuilder.DropTable(
                name: "Alimento");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
