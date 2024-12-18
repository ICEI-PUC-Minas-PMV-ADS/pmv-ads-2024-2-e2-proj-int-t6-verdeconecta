﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using verdeconecta.Models;

#nullable disable

namespace verdeconecta.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("verdeconecta.Models.Alimento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<float>("Calorias")
                        .HasColumnType("real");

                    b.Property<float>("Carboidratos")
                        .HasColumnType("real");

                    b.Property<float>("Fibras")
                        .HasColumnType("real");

                    b.Property<float>("Gorduras")
                        .HasColumnType("real");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Proteinas")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Alimento");
                });

            modelBuilder.Entity("verdeconecta.Models.DicasNutricionais", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataDica")
                        .HasColumnType("datetime2");

                    b.Property<string>("Dica")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Dislikes")
                        .HasColumnType("int");

                    b.Property<int>("Likes")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DicasNutricionais");
                });

            modelBuilder.Entity("verdeconecta.Models.Meta", b =>
                {
                    b.Property<int>("IDMe")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDMe"));

                    b.Property<DateTime>("DaraCriacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<float>("MetaFibras")
                        .HasColumnType("real");

                    b.Property<DateTime>("duracaoDaMeta")
                        .HasColumnType("datetime2");

                    b.Property<int>("idUsuario")
                        .HasColumnType("int");

                    b.Property<float>("metaCalorica")
                        .HasColumnType("real");

                    b.Property<float>("metaCarboidratos")
                        .HasColumnType("real");

                    b.Property<float>("metaGorduraTotais")
                        .HasColumnType("real");

                    b.Property<float>("metaProteinas")
                        .HasColumnType("real");

                    b.Property<float>("metaSodio")
                        .HasColumnType("real");

                    b.HasKey("IDMe");

                    b.HasIndex("idUsuario");

                    b.ToTable("Meta");
                });

            modelBuilder.Entity("verdeconecta.Models.Questionario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ConsumoFrutasVegetais")
                        .HasColumnType("int");

                    b.Property<int>("HorarioRefeicoes")
                        .HasColumnType("int");

                    b.Property<int>("NivelAtividadeFisica")
                        .HasColumnType("int");

                    b.Property<int>("ObjetivoPrincipal")
                        .HasColumnType("int");

                    b.Property<int>("RefeicoesPorDia")
                        .HasColumnType("int");

                    b.Property<string>("RestricaoDetalhes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TemRestricaoAlimentar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TipoDieta")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId")
                        .IsUnique();

                    b.ToTable("Questionarios");
                });

            modelBuilder.Entity("verdeconecta.Models.Refeicao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AlimentoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataDaRefeicao")
                        .HasColumnType("datetime2");

                    b.Property<float>("Quantidade")
                        .HasColumnType("real");

                    b.Property<int>("TipoRefeicao")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AlimentoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Refeicao");
                });

            modelBuilder.Entity("verdeconecta.Models.RelacionamentoNutricionistaCliente", b =>
                {
                    b.Property<int>("IdNutricionista")
                        .HasColumnType("int");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.HasKey("IdNutricionista", "IdCliente");

                    b.HasIndex("IdCliente");

                    b.ToTable("RelacionamentoNutricionistaCliente");
                });

            modelBuilder.Entity("verdeconecta.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<float>("Altura")
                        .HasColumnType("real");

                    b.Property<DateTime>("DataDeNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Perfil")
                        .HasColumnType("int");

                    b.Property<float>("Peso")
                        .HasColumnType("real");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TokenRedefinicaoSenha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("TokenValidade")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("verdeconecta.Models.Meta", b =>
                {
                    b.HasOne("verdeconecta.Models.Usuario", "Usuario")
                        .WithMany("Metas")
                        .HasForeignKey("idUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("verdeconecta.Models.Questionario", b =>
                {
                    b.HasOne("verdeconecta.Models.Usuario", "Usuario")
                        .WithOne("Questionario")
                        .HasForeignKey("verdeconecta.Models.Questionario", "UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("verdeconecta.Models.Refeicao", b =>
                {
                    b.HasOne("verdeconecta.Models.Alimento", "Alimento")
                        .WithMany("Refeicoes")
                        .HasForeignKey("AlimentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("verdeconecta.Models.Usuario", "Usuario")
                        .WithMany("Refeicoes")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Alimento");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("verdeconecta.Models.RelacionamentoNutricionistaCliente", b =>
                {
                    b.HasOne("verdeconecta.Models.Usuario", "Cliente")
                        .WithMany()
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("verdeconecta.Models.Usuario", "Nutricionista")
                        .WithMany()
                        .HasForeignKey("IdNutricionista")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Nutricionista");
                });

            modelBuilder.Entity("verdeconecta.Models.Alimento", b =>
                {
                    b.Navigation("Refeicoes");
                });

            modelBuilder.Entity("verdeconecta.Models.Usuario", b =>
                {
                    b.Navigation("Metas");

                    b.Navigation("Questionario");

                    b.Navigation("Refeicoes");
                });
#pragma warning restore 612, 618
        }
    }
}
