using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VacineMais.API.Migrations
{
    /// <inheritdoc />
    public partial class TabelaUsuarioAdicionaColunaAtivo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Usuarios",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Usuarios");
        }
    }
}
