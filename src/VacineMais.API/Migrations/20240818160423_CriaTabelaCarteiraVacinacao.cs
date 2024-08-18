using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VacineMais.API.Migrations
{
    /// <inheritdoc />
    public partial class CriaTabelaCarteiraVacinacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarteiraVacinacaoId",
                table: "Membro",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CarteiraVacinacaoId",
                table: "Imunizacao",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CarteiraVacinacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MembroId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarteiraVacinacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarteiraVacinacao_Membro_MembroId",
                        column: x => x.MembroId,
                        principalTable: "Membro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Imunizacao_CarteiraVacinacaoId",
                table: "Imunizacao",
                column: "CarteiraVacinacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_CarteiraVacinacao_MembroId",
                table: "CarteiraVacinacao",
                column: "MembroId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Imunizacao_CarteiraVacinacao_CarteiraVacinacaoId",
                table: "Imunizacao",
                column: "CarteiraVacinacaoId",
                principalTable: "CarteiraVacinacao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Imunizacao_CarteiraVacinacao_CarteiraVacinacaoId",
                table: "Imunizacao");

            migrationBuilder.DropTable(
                name: "CarteiraVacinacao");

            migrationBuilder.DropIndex(
                name: "IX_Imunizacao_CarteiraVacinacaoId",
                table: "Imunizacao");

            migrationBuilder.DropColumn(
                name: "CarteiraVacinacaoId",
                table: "Membro");

            migrationBuilder.DropColumn(
                name: "CarteiraVacinacaoId",
                table: "Imunizacao");
        }
    }
}
