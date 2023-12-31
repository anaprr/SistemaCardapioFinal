﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemaCardapioFinal.Models;

#nullable disable

namespace SistemaCardapioFinal.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20231018180437_Criacao-Novo-Modelo")]
    partial class CriacaoNovoModelo
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SistemaCardapioFinal.Models.Acompanhamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("AcompanhamentoId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DescricaoAcompanhamento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("DescricaoAcompanhamento");

                    b.HasKey("Id");

                    b.ToTable("Acompanhamento");
                });

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

            modelBuilder.Entity("SistemaCardapioFinal.Models.Base", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("BaseId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DescricaoBase")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("DescricaoBase");

                    b.HasKey("Id");

                    b.ToTable("Base");
                });

            modelBuilder.Entity("SistemaCardapioFinal.Models.Bebida", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("BebidaId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DescricaoBebida")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("DescricaoBebida");

                    b.HasKey("Id");

                    b.ToTable("Bebida");
                });

            modelBuilder.Entity("SistemaCardapioFinal.Models.Cardapio", b =>
                {
                    b.Property<int>("CardapioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CardapioId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CardapioId"));

                    b.Property<int>("AcompanhamentoId")
                        .HasColumnType("int");

                    b.Property<int>("BaseId")
                        .HasColumnType("int");

                    b.Property<int>("BebidaId")
                        .HasColumnType("int");

                    b.Property<string>("CardapioNome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CardapioNome");

                    b.Property<int>("SaladaId")
                        .HasColumnType("int");

                    b.Property<int>("SobremesaId")
                        .HasColumnType("int");

                    b.HasKey("CardapioId");

                    b.HasIndex("AcompanhamentoId");

                    b.HasIndex("BaseId");

                    b.HasIndex("BebidaId");

                    b.HasIndex("SaladaId");

                    b.HasIndex("SobremesaId");

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

            modelBuilder.Entity("SistemaCardapioFinal.Models.Salada", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("SaladaId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DescricaoSalada")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("DescricaoSalada");

                    b.HasKey("Id");

                    b.ToTable("Salada");
                });

            modelBuilder.Entity("SistemaCardapioFinal.Models.Sobremesa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("SobremesaId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DescricaoSobremesa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("DescricaoSobremesa");

                    b.HasKey("Id");

                    b.ToTable("Sobremesa");
                });

            modelBuilder.Entity("SistemaCardapioFinal.Models.Cardapio", b =>
                {
                    b.HasOne("SistemaCardapioFinal.Models.Acompanhamento", "Acompanhamento")
                        .WithMany()
                        .HasForeignKey("AcompanhamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemaCardapioFinal.Models.Base", "Base")
                        .WithMany()
                        .HasForeignKey("BaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemaCardapioFinal.Models.Bebida", "Bebida")
                        .WithMany()
                        .HasForeignKey("BebidaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemaCardapioFinal.Models.Salada", "Salada")
                        .WithMany()
                        .HasForeignKey("SaladaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemaCardapioFinal.Models.Sobremesa", "Sobremesa")
                        .WithMany()
                        .HasForeignKey("SobremesaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Acompanhamento");

                    b.Navigation("Base");

                    b.Navigation("Bebida");

                    b.Navigation("Salada");

                    b.Navigation("Sobremesa");
                });
#pragma warning restore 612, 618
        }
    }
}
