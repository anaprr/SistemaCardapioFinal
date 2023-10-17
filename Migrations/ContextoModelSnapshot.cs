﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemaCardapioFinal.Models;

#nullable disable

namespace SistemaCardapioFinal.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SistemaCardapioFinal.Models.Aluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AlunoNome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("AlunoNome");

                    b.HasKey("Id");

                    b.ToTable("Aluno");
                });

            modelBuilder.Entity("SistemaCardapioFinal.Models.Cardapio", b =>
                {
                    b.Property<int>("CardapioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CardapioId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CardapioId"));

                    b.Property<string>("CardapioNome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CardapioNome");

                    b.Property<int>("PratoId")
                        .HasColumnType("int");

                    b.HasKey("CardapioId");

                    b.HasIndex("PratoId");

                    b.ToTable("Cardapio");
                });

            modelBuilder.Entity("SistemaCardapioFinal.Models.Desperdicio", b =>
                {
                    b.Property<int>("DesperdicioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("DesperdicioId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DesperdicioId"));

                    b.Property<DateTime>("NomeVeiculo")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataDesperdicio");

                    b.Property<double>("PorcentagemDesperdicio")
                        .HasColumnType("float")
                        .HasColumnName("PorcentagemDesperdicio");

                    b.Property<int>("QtdAlimento")
                        .HasColumnType("int")
                        .HasColumnName("QtdAlimento");

                    b.Property<int>("QtdDesperdicio")
                        .HasColumnType("int")
                        .HasColumnName("QtdDesperdicio");

                    b.HasKey("DesperdicioId");

                    b.ToTable("Desperdicio");
                });

            modelBuilder.Entity("SistemaCardapioFinal.Models.Prato", b =>
                {
                    b.Property<int>("PratoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PratoId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PratoId"));

                    b.Property<string>("DescricaoBebida")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("DescricaoBebida");

                    b.Property<string>("DescricaoPrato")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("DescricaoPrato");

                    b.Property<string>("DescricaoVegetariana")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("DescricaoVegetariana");

                    b.HasKey("PratoId");

                    b.ToTable("Prato");
                });

            modelBuilder.Entity("SistemaCardapioFinal.Models.Cardapio", b =>
                {
                    b.HasOne("SistemaCardapioFinal.Models.Prato", "Prato")
                        .WithMany()
                        .HasForeignKey("PratoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Prato");
                });
#pragma warning restore 612, 618
        }
    }
}
