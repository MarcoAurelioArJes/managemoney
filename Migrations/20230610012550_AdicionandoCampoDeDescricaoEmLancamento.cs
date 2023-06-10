using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManageMoney.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoCampoDeDescricaoEmLancamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Lancamentos",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Lancamentos");
        }
    }
}
