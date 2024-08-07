using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VacineMais.API.Migrations
{
    /// <inheritdoc />
    public partial class CriaTabelaImunizacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Imunizacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MembroId = table.Column<int>(type: "INTEGER", nullable: false),
                    ImunobiologicoId = table.Column<int>(type: "INTEGER", nullable: false),
                    DoseId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProximaDoseEm = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imunizacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Imunizacao_Dose_DoseId",
                        column: x => x.DoseId,
                        principalTable: "Dose",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Imunizacao_Imunobiologico_ImunobiologicoId",
                        column: x => x.ImunobiologicoId,
                        principalTable: "Imunobiologico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Imunizacao_Membro_MembroId",
                        column: x => x.MembroId,
                        principalTable: "Membro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Imunizacao_DoseId",
                table: "Imunizacao",
                column: "DoseId");

            migrationBuilder.CreateIndex(
                name: "IX_Imunizacao_ImunobiologicoId",
                table: "Imunizacao",
                column: "ImunobiologicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Imunizacao_MembroId",
                table: "Imunizacao",
                column: "MembroId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Imunizacao");
        }
    }
}
