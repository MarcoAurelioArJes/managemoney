using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManageMoney.Migrations
{
    /// <inheritdoc />
    public partial class RemovendoCamposDoLancamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notificacao",
                table: "Lancamentos");

            migrationBuilder.DropColumn(
                name: "Recorrente",
                table: "Lancamentos");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Lancamentos",
                type: "nvarchar(3000)",
                maxLength: 3000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Lancamentos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(3000)",
                oldMaxLength: 3000,
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Notificacao",
                table: "Lancamentos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Recorrente",
                table: "Lancamentos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
