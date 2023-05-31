using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManageMoney.Migrations
{
    /// <inheritdoc />
    public partial class CriandoTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoriaModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioID = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FornecedorModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioID = table.Column<int>(type: "int", nullable: false),
                    NomeFantasia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CpfCnpj = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FornecedorModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoriaFornecedorModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FornecedorID = table.Column<int>(type: "int", nullable: false),
                    CategoriaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaFornecedorModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoriaFornecedorModel_CategoriaModel_CategoriaID",
                        column: x => x.CategoriaID,
                        principalTable: "CategoriaModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoriaFornecedorModel_FornecedorModel_FornecedorID",
                        column: x => x.FornecedorID,
                        principalTable: "FornecedorModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LancamentoModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    FornecedorId = table.Column<int>(type: "int", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataLancamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoDeLancamento = table.Column<int>(type: "int", nullable: false),
                    Recorrente = table.Column<bool>(type: "bit", nullable: false),
                    Notificacao = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LancamentoModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LancamentoModel_CategoriaModel_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "CategoriaModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LancamentoModel_FornecedorModel_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "FornecedorModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LancamentoModel_UsuarioModel_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "UsuarioModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MetasModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    RelacionarMesAnterior = table.Column<bool>(type: "bit", nullable: false),
                    RelacionarPorCategoria = table.Column<bool>(type: "bit", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Finalizada = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetasModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MetasModel_CategoriaModel_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "CategoriaModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MetasModel_UsuarioModel_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "UsuarioModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoriaFornecedorModel_CategoriaID",
                table: "CategoriaFornecedorModel",
                column: "CategoriaID");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriaFornecedorModel_FornecedorID",
                table: "CategoriaFornecedorModel",
                column: "FornecedorID");

            migrationBuilder.CreateIndex(
                name: "IX_LancamentoModel_CategoriaId",
                table: "LancamentoModel",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_LancamentoModel_FornecedorId",
                table: "LancamentoModel",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_LancamentoModel_UsuarioId",
                table: "LancamentoModel",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_MetasModel_CategoriaId",
                table: "MetasModel",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_MetasModel_UsuarioId",
                table: "MetasModel",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoriaFornecedorModel");

            migrationBuilder.DropTable(
                name: "LancamentoModel");

            migrationBuilder.DropTable(
                name: "MetasModel");

            migrationBuilder.DropTable(
                name: "FornecedorModel");

            migrationBuilder.DropTable(
                name: "CategoriaModel");

            migrationBuilder.DropTable(
                name: "UsuarioModel");
        }
    }
}
