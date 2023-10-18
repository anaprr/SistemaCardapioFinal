using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaCardapioFinal.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoNovoModelo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Acompanhamento",
                columns: table => new
                {
                    AcompanhamentoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescricaoAcompanhamento = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acompanhamento", x => x.AcompanhamentoId);
                });

            migrationBuilder.CreateTable(
                name: "Aluno",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlunoNome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aluno", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Base",
                columns: table => new
                {
                    BaseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescricaoBase = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Base", x => x.BaseId);
                });

            migrationBuilder.CreateTable(
                name: "Bebida",
                columns: table => new
                {
                    BebidaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescricaoBebida = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bebida", x => x.BebidaId);
                });

            migrationBuilder.CreateTable(
                name: "Desperdicio",
                columns: table => new
                {
                    DesperdicioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataDesperdicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QtdAlimento = table.Column<int>(type: "int", nullable: false),
                    QtdDesperdicio = table.Column<int>(type: "int", nullable: false),
                    PorcentagemDesperdicio = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desperdicio", x => x.DesperdicioId);
                });

            migrationBuilder.CreateTable(
                name: "Salada",
                columns: table => new
                {
                    SaladaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescricaoSalada = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salada", x => x.SaladaId);
                });

            migrationBuilder.CreateTable(
                name: "Sobremesa",
                columns: table => new
                {
                    SobremesaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescricaoSobremesa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sobremesa", x => x.SobremesaId);
                });

            migrationBuilder.CreateTable(
                name: "Cardapio",
                columns: table => new
                {
                    CardapioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardapioNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BaseId = table.Column<int>(type: "int", nullable: false),
                    AcompanhamentoId = table.Column<int>(type: "int", nullable: false),
                    SaladaId = table.Column<int>(type: "int", nullable: false),
                    BebidaId = table.Column<int>(type: "int", nullable: false),
                    SobremesaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cardapio", x => x.CardapioId);
                    table.ForeignKey(
                        name: "FK_Cardapio_Acompanhamento_AcompanhamentoId",
                        column: x => x.AcompanhamentoId,
                        principalTable: "Acompanhamento",
                        principalColumn: "AcompanhamentoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cardapio_Base_BaseId",
                        column: x => x.BaseId,
                        principalTable: "Base",
                        principalColumn: "BaseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cardapio_Bebida_BebidaId",
                        column: x => x.BebidaId,
                        principalTable: "Bebida",
                        principalColumn: "BebidaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cardapio_Salada_SaladaId",
                        column: x => x.SaladaId,
                        principalTable: "Salada",
                        principalColumn: "SaladaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cardapio_Sobremesa_SobremesaId",
                        column: x => x.SobremesaId,
                        principalTable: "Sobremesa",
                        principalColumn: "SobremesaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cardapio_AcompanhamentoId",
                table: "Cardapio",
                column: "AcompanhamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Cardapio_BaseId",
                table: "Cardapio",
                column: "BaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Cardapio_BebidaId",
                table: "Cardapio",
                column: "BebidaId");

            migrationBuilder.CreateIndex(
                name: "IX_Cardapio_SaladaId",
                table: "Cardapio",
                column: "SaladaId");

            migrationBuilder.CreateIndex(
                name: "IX_Cardapio_SobremesaId",
                table: "Cardapio",
                column: "SobremesaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aluno");

            migrationBuilder.DropTable(
                name: "Cardapio");

            migrationBuilder.DropTable(
                name: "Desperdicio");

            migrationBuilder.DropTable(
                name: "Acompanhamento");

            migrationBuilder.DropTable(
                name: "Base");

            migrationBuilder.DropTable(
                name: "Bebida");

            migrationBuilder.DropTable(
                name: "Salada");

            migrationBuilder.DropTable(
                name: "Sobremesa");
        }
    }
}
