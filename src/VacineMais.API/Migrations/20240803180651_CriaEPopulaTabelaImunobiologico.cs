using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VacineMais.API.Migrations
{
    /// <inheritdoc />
    public partial class CriaEPopulaTabelaImunobiologico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Imunobiologico",
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
                    table.PrimaryKey("PK_Imunobiologico", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Imunobiologico",
                columns: new[] { "Id", "Codigo", "Descricao", "Sigla" },
                values: new object[,]
                {
                    { 1, 1, "Imunoglobulina humana antitétano", "IGHT" },
                    { 2, 2, "Soro antitetânico", "SAT" },
                    { 3, 3, "soro antiaracnídico", "SARC" },
                    { 4, 4, "Soro antiescorpiônico", "SAESCOR" },
                    { 5, 5, "Vacina difteria e tétano infantil", "DT" },
                    { 6, 6, "Soro antielapídico", "SAELAP" },
                    { 7, 7, "Soro antirrábico", "SAR" },
                    { 8, 8, "Soro antibotrópico (pentavalente)", "SABOTR" },
                    { 9, 9, "Vacina hepatite B", "HepB" },
                    { 10, 10, "Soro antidiftérico", "SAD" },
                    { 11, 11, "Soro antibotrópico (pentavalente) e anticrotálico", "SABOCR" },
                    { 12, 12, "Soro antibotrópico (pentavalente) e antilaquético", "SABOLA" },
                    { 13, 13, "Vacina meningocócica AC", "Meningo AC" },
                    { 14, 14, "Vacina febre amarela", "VFA" },
                    { 15, 15, "Vacina BCG", "BCG" },
                    { 16, 16, "Soro anticrotálico", "SACROT" },
                    { 17, 17, "Vacina Hib", "Hib" },
                    { 18, 18, "Vacina raiva embrião de galinha", "VR" },
                    { 19, 19, "Imunoglobulina humana antivaricela", "IGHV" },
                    { 20, 20, "Imunoglobulina humana anti-hepatite B", "IGHHB" },
                    { 21, 21, "Vacina pneumo 23", "VPP23" },
                    { 22, 22, "Vacina polio injetável", "VIP" },
                    { 23, 23, "Imunoglobulina humana antirrábica", "IGHR" },
                    { 24, 24, "Vacina sarampo, caxumba, rubéola", "SCR" },
                    { 25, 25, "Vacina difteria e tétano adulto", "dT" },
                    { 26, 26, "Vacina pneumo 10", "VPC10" },
                    { 28, 28, "Vacina polio oral", "VOP" },
                    { 29, 29, "Vacina penta acelular (DTPa/VIP/Hib)", "PENTA acelular" },
                    { 30, 30, "Vacina febre tifóide", "FTp" },
                    { 31, 31, "Soro antiloxoscélico (trivalente)", "SALOXO" },
                    { 32, 32, "Soro antilonômico", "SALONO" },
                    { 33, 33, "Vacina influenza trivalente", "INF3" },
                    { 34, 34, "Vacina varicela", "VAR" },
                    { 35, 35, "Vacina hepatite A", "HA" },
                    { 36, 36, "Vacina sarampo, rubéola", "SR" },
                    { 37, 37, "Vacina raiva em cultivo celular vero", "Vero" },
                    { 38, 38, "Soro antibotulínico (trivalente)", "SBOTULTRI" },
                    { 39, 39, "Vacina DTP/Hib", "Tetra" },
                    { 40, 40, "Vacina pneumocócica 7V", "Pncc7V" },
                    { 41, 41, "Vacina meningo C", "MenC" },
                    { 42, 42, "Vacina penta (DTP/HepB/Hib)", "PENTA" },
                    { 43, 43, "Vacina hexa (DTPa/HepB/VIP/Hib)", "HEXA" },
                    { 44, 44, "Vacina Influenza H1N1", "H1N1" },
                    { 45, 45, "Vacina rotavírus", "ROTA" },
                    { 46, 46, "Vacina DTP", "DTP" },
                    { 47, 47, "Vacina DTPa infantil", "DTPa" },
                    { 51, 51, "Vacina febre tifóide (atenuada)", "Fta" },
                    { 55, 55, "Vacina hepatite A infantil", "HepAinf" },
                    { 56, 56, "Vacina sarampo, caxumba, rubéola e varicela", "SCRV" },
                    { 57, 57, "Vacina dTpa adulto", "dTpa" },
                    { 58, 58, "Vacina DTPa/VIP", "TETRA acelular" },
                    { 59, 59, "Vacina pneumo 13", "VPC13" },
                    { 60, 60, "Vacina HPV bivalente", "HPV2" },
                    { 61, 61, "Vacina toxóide tetânico", "TT" },
                    { 62, 62, "Hepatite AeB(pediátrica)", "HAeHBped" },
                    { 63, 63, "Vacina hepatite AeB(uso adulto)", "HAeHB" },
                    { 64, 64, "Vacina influenza ID", "FLU ID" },
                    { 65, 65, "Vacina rotavírus pentavalente", "ROTA5" },
                    { 66, 66, "Vacina meningocócica B/C", "MEN BC" },
                    { 67, 67, "Vacina HPV quadrivalente", "HPV4" },
                    { 69, 69, "Soro antibotulínico AB (bivalente)", "SABOT" },
                    { 70, 70, "Vacina sarampo", "Sarampo" },
                    { 71, 71, "Vacina rubéola", "Rubeola" },
                    { 72, 72, "Vacina gripe", "Gripe Sazonal" },
                    { 73, 73, "Vacina quádrupla viral", "Quadrupla Viral" },
                    { 74, 74, "Vacina meningo ACWY", "MenACWY" },
                    { 75, 75, "Vacina cólera", "COLERA" },
                    { 76, 76, "Vacina herpes-zóster", "VHZ" },
                    { 77, 77, "Vacina influenza tetravalente", "INF4" },
                    { 78, 78, "Vacina meningo B", "MenB" },
                    { 82, 82, "Vacina dengue", "Dengue" },
                    { 83, 83, "Vacina hepatite A adulto", "HEPAad" },
                    { 84, 84, "Vacina febre amarela fracionada", "VFA-F" },
                    { 85, 85, "Vacina COVID-19-recombinante, AstraZeneca/Fiocruz (Covishield)", "COVID-19 ASTRAZENECA/FIOCRUZ - COVISHIELD" },
                    { 86, 86, "Vacina COVID-19-inativada, Sinovac/Butantan (Coronavac)", "COVID-19 SINOVAC/BUTANTAN - CORONAVAC" },
                    { 87, 87, "Vacina COVID-19-RNAm, Pfizer (Comirnaty)", "COVID-19 PFIZER - COMIRNATY" },
                    { 88, 88, "Vacina COVID-19-recombinante, Janssen (Ad26.COV2.S)", "COVID-19 JANSSEN - Ad26.COV2.S" },
                    { 89, 89, "Vacina COVID-19-recombinante, AstraZeneca/Covax (ChAdOx1-S)", "COVID-19 ASTRAZENECA - ChAdOx1-S" },
                    { 97, 97, "vacina COVID-19-RNAm, Moderna (Spikevax)", "COVID-19 MODERNA - SPIKEVAX" },
                    { 98, 98, "Vacina COVID-19-inativada, Sinovac (Coronavac)", "COVID-19 SINOVAC - CORONAVAC" },
                    { 99, 99, "Vacina COVID-19-RNAm, Pfizer (Comirnaty) pediátrica", "COVID-19 PFIZER - COMIRNATY PEDIÁTRICA" },
                    { 100, 100, "Vacina Varíola Bavarian Nordic", "VVBN" },
                    { 101, 101, "Vacina Herpes-Zoster (recombinante)", "VZR" },
                    { 102, 102, "Vacina COVID-19-RNAm, Pfizer (Comirnaty) pediátrica menor de 5 anos", "COVID-19 PFIZER - COMIRNATY PEDIÁTRICA MENOR DE 5 ANOS" },
                    { 103, 103, "Vacina COVID-19-RNAm, Pfizer (Comirnaty) bivalente", "COVID-19 PFIZER - COMIRNATY BIVALENTE" },
                    { 104, 104, "Vacina dengue (atenuada)", "DNG" },
                    { 105, 105, "Vacina Covid-19-RNAm, Moderna (Spikevax) bivalente", "COVID-19 MODERNA - SPIKEVAX BIVALENTE" },
                    { 106, 106, "Vacina adsorvida pneumocócica 15-valente (conjugada, polissacarídica)", "VPC15" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Imunobiologico_Codigo",
                table: "Imunobiologico",
                column: "Codigo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Imunobiologico");
        }
    }
}
