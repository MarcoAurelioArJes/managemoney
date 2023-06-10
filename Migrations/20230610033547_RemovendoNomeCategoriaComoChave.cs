using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManageMoney.Migrations
{
    /// <inheritdoc />
    public partial class RemovendoNomeCategoriaComoChave : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Categorias_Nome",
                table: "Categorias");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "AK_Categorias_Nome",
                table: "Categorias",
                column: "Nome");
        }
    }
}
