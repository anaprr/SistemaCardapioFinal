using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaCardapioFinal.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoSistemaCardapioFinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Prato",
                columns: table => new
                {
                    PratoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescricaoPrato = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescricaoBebida = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescricaoVegetariana = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prato", x => x.PratoId);
                });

            migrationBuilder.CreateTable(
                name: "Cardapio",
                columns: table => new
                {
                    CardapioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardapioNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PratoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cardapio", x => x.CardapioId);
                    table.ForeignKey(
                        name: "FK_Cardapio_Prato_PratoId",
                        column: x => x.PratoId,
                        principalTable: "Prato",
                        principalColumn: "PratoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cardapio_PratoId",
                table: "Cardapio",
                column: "PratoId");
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
                name: "Prato");
        }
    }
}
