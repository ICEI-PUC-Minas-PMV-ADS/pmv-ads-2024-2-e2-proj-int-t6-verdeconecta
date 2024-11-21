﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using verdeconecta.Models;

#nullable disable

namespace verdeconecta.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241120235353_CriacaoMetasCorrecao")]
    partial class CriacaoMetasCorrecao
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
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

                    b.Property<int>("Gramas")
                        .HasColumnType("int");

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

                    b.Property<int>("IdNutricionista")
                        .HasColumnType("int");

                    b.Property<float>("MetaFibras")
                        .HasColumnType("real");

                    b.Property<DateTime>("duracaoDaMeta")
                        .HasColumnType("datetime2");

                    b.Property<int?>("idNutricionista")
                        .HasColumnType("int");

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

                    b.HasIndex("idNutricionista");

                    b.HasIndex("idUsuario");

                    b.ToTable("Metas");
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

                    b.Property<int>("TipoRefeicao")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AlimentoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Refeicao");
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
                    b.HasOne("verdeconecta.Models.Usuario", "Nutricionista")
                        .WithMany()
                        .HasForeignKey("idNutricionista");

                    b.HasOne("verdeconecta.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("idUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Nutricionista");

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

            modelBuilder.Entity("verdeconecta.Models.Alimento", b =>
                {
                    b.Navigation("Refeicoes");
                });

            modelBuilder.Entity("verdeconecta.Models.Usuario", b =>
                {
                    b.Navigation("Refeicoes");
                });
#pragma warning restore 612, 618
        }
    }
}
