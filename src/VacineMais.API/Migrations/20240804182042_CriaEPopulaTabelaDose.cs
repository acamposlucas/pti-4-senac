using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VacineMais.API.Migrations
{
    /// <inheritdoc />
    public partial class CriaEPopulaTabelaDose : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dose",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Codigo = table.Column<int>(type: "INTEGER", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: false),
                    Sigla = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dose", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Dose",
                columns: new[] { "Id", "Codigo", "Descricao", "Sigla" },
                values: new object[,]
                {
                    { 1, 1, "1ª Dose", "D1" },
                    { 2, 2, "2ª Dose", "D2" },
                    { 3, 3, "3ª Dose", "D3" },
                    { 4, 4, "4ª Dose", "D4" },
                    { 5, 5, "5ª Dose", "D5" },
                    { 6, 6, "1º Reforço", "R1" },
                    { 7, 7, "2º Reforço", "R2" },
                    { 8, 8, "Dose", "D" },
                    { 9, 9, "Única", "DU" },
                    { 10, 10, "Revacinação", "REV" },
                    { 11, 11, "Tratamento com uma dose", "T1" },
                    { 12, 12, "Tratamento com duas doses", "T2" },
                    { 13, 13, "Tratamento com três doses", "T3" },
                    { 14, 14, "Tratamento com quatro doses", "T4" },
                    { 15, 15, "Tratamento com cinco doses", "T5" },
                    { 16, 16, "Tratamento com seis doses", "T6" },
                    { 17, 17, "Tratamento com sete doses", "T7" },
                    { 18, 18, "Tratamento com oito doses", "T8" },
                    { 19, 19, "Tratamento com nove doses", "T9" },
                    { 20, 20, "Tratamento com dez doses", "T10" },
                    { 21, 21, "Tratamento com onze doses", "T11" },
                    { 22, 22, "Tratamento com doze doses", "T12" },
                    { 23, 23, "Tratamento com treze doses", "T13" },
                    { 24, 24, "Tratamento com quatorze doses", "T14" },
                    { 25, 25, "Tratamento com quinze doses", "T15" },
                    { 26, 26, "Tratamento com dezesseis doses", "T16" },
                    { 27, 27, "Tratamento com dezessete doses", "T17" },
                    { 28, 28, "Tratamento com dezoito doses", "T18" },
                    { 29, 29, "Tratamento com dezenove doses", "T19" },
                    { 30, 30, "Tratamento com vinte doses", "T20" },
                    { 31, 31, "Tratamento com vinte quatro doses", "T24" },
                    { 32, 32, "1ª Dose Revacinação", "D1REV" },
                    { 33, 33, "2ª Dose Revacinação", "D2REV" },
                    { 34, 34, "3ª Dose Revacinação", "D3REV" },
                    { 35, 35, "4ª Dose Revacinação", "D4REV" },
                    { 36, 36, "Dose Inicial", "DI" },
                    { 37, 37, "Dose Adicional", "DA" },
                    { 38, 38, "Reforço", "REF" },
                    { 39, 39, "3º Reforço", "R3" },
                    { 40, 40, "4º Reforço", "R4" },
                    { 41, 41, "5º Reforço", "R5" },
                    { 42, 42, "6º Reforço", "R6" },
                    { 43, 43, "5ª Dose Revacinacao", "D5REV" },
                    { 44, 44, "1ª Dose Fracionada", "D1F" },
                    { 45, 45, "2ª Dose Fracionada", "D2F" },
                    { 46, 46, "3ª Dose Fracionada", "D3F" },
                    { 47, 47, "4ª Dose Fracionada", "D4F" },
                    { 48, 48, "5ª Dose Fracionada", "D5F" },
                    { 49, 49, "1ª Dose Dobrada", "D1D" },
                    { 50, 50, "2ª Dose Dobrada", "D2D" },
                    { 51, 51, "3ª Dose Dobrada", "D3D" },
                    { 52, 52, "4ª Dose Dobrada", "D4D" },
                    { 53, 53, "1ª Dose Revacinação Dobrada", "D1REVD" },
                    { 54, 54, "2ª Dose Revacinação Dobrada", "D2REVD" },
                    { 55, 55, "3ª Dose Revacinação Dobrada", "D3REVD" },
                    { 56, 56, "4ª Dose Revacinação Dobrada", "D4REVD" },
                    { 57, 57, "Dose Zero", "D0" },
                    { 58, 58, "Reforço Zero", "R0" },
                    { 59, 59, "Profilaxia com 1 frasco-ampola/ampola", "P1" },
                    { 60, 60, "Profilaxia com 2 frascos-ampolas/ampolas", "P2" },
                    { 61, 61, "Profilaxia com 3 frascos-ampolas/ampolas", "P3" },
                    { 62, 62, "Profilaxia com 4 frascos-ampolas/ampolas", "P4" },
                    { 63, 63, "Profilaxia com 5 frascos-ampolas/ampolas", "P5" },
                    { 64, 64, "Profilaxia com 6 frascos-ampolas/ampolas", "P6" },
                    { 65, 65, "Profilaxia com 7 frascos-ampolas/ampolas", "P7" },
                    { 66, 66, "Profilaxia com 8 frascos-ampolas/ampolas", "P8" },
                    { 67, 67, "Profilaxia com 9 frascos-ampolas/ampolas", "P9" },
                    { 68, 68, "Profilaxia com 10 frascos-ampolas/ampolas", "P10" },
                    { 69, 69, "Profilaxia com 11 frascos-ampolas/ampolas", "P11" },
                    { 70, 70, "Profilaxia com 12 frascos-ampolas/ampolas", "P12" },
                    { 71, 71, "Profilaxia com 13 frascos-ampolas/ampolas", "P13" },
                    { 72, 72, "Profilaxia com 14 frascos-ampolas/ampolas", "P14" },
                    { 73, 73, "Profilaxia com 15 frascos-ampolas/ampolas", "P15" },
                    { 74, 74, "Profilaxia com 16 frascos-ampolas/ampolas", "P16" },
                    { 75, 75, "Profilaxia com 17 frascos-ampolas/ampolas", "P17" },
                    { 76, 76, "Profilaxia com 18 frascos-ampolas/ampolas", "P18" },
                    { 77, 77, "Profilaxia com 19 frascos-ampolas/ampolas", "P19" },
                    { 78, 78, "Profilaxia com 20 frascos-ampolas/ampolas", "P20" },
                    { 79, 79, "Profilaxia com 21 frascos-ampolas/ampolas", "P21" },
                    { 80, 80, "Profilaxia com 22 frascos-ampolas/ampolas", "P22" },
                    { 81, 81, "Profilaxia com 23 frascos-ampolas/ampolas", "P23" },
                    { 82, 82, "Profilaxia com 24 frascos-ampolas/ampolas", "P24" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dose");
        }
    }
}
