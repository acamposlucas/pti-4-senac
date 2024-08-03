﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VacineMais.API.Data;

#nullable disable

namespace VacineMais.API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.7");

            modelBuilder.Entity("VacineMais.API.Models.Familia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Familia");
                });

            modelBuilder.Entity("VacineMais.API.Models.Imunobiologico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Codigo")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Sigla")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Codigo");

                    b.ToTable("Imunobiologico");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Codigo = 1,
                            Descricao = "Imunoglobulina humana antitétano",
                            Sigla = "IGHT"
                        },
                        new
                        {
                            Id = 2,
                            Codigo = 2,
                            Descricao = "Soro antitetânico",
                            Sigla = "SAT"
                        },
                        new
                        {
                            Id = 3,
                            Codigo = 3,
                            Descricao = "soro antiaracnídico",
                            Sigla = "SARC"
                        },
                        new
                        {
                            Id = 4,
                            Codigo = 4,
                            Descricao = "Soro antiescorpiônico",
                            Sigla = "SAESCOR"
                        },
                        new
                        {
                            Id = 5,
                            Codigo = 5,
                            Descricao = "Vacina difteria e tétano infantil",
                            Sigla = "DT"
                        },
                        new
                        {
                            Id = 6,
                            Codigo = 6,
                            Descricao = "Soro antielapídico",
                            Sigla = "SAELAP"
                        },
                        new
                        {
                            Id = 7,
                            Codigo = 7,
                            Descricao = "Soro antirrábico",
                            Sigla = "SAR"
                        },
                        new
                        {
                            Id = 8,
                            Codigo = 8,
                            Descricao = "Soro antibotrópico (pentavalente)",
                            Sigla = "SABOTR"
                        },
                        new
                        {
                            Id = 9,
                            Codigo = 9,
                            Descricao = "Vacina hepatite B",
                            Sigla = "HepB"
                        },
                        new
                        {
                            Id = 10,
                            Codigo = 10,
                            Descricao = "Soro antidiftérico",
                            Sigla = "SAD"
                        },
                        new
                        {
                            Id = 11,
                            Codigo = 11,
                            Descricao = "Soro antibotrópico (pentavalente) e anticrotálico",
                            Sigla = "SABOCR"
                        },
                        new
                        {
                            Id = 12,
                            Codigo = 12,
                            Descricao = "Soro antibotrópico (pentavalente) e antilaquético",
                            Sigla = "SABOLA"
                        },
                        new
                        {
                            Id = 13,
                            Codigo = 13,
                            Descricao = "Vacina meningocócica AC",
                            Sigla = "Meningo AC"
                        },
                        new
                        {
                            Id = 14,
                            Codigo = 14,
                            Descricao = "Vacina febre amarela",
                            Sigla = "VFA"
                        },
                        new
                        {
                            Id = 15,
                            Codigo = 15,
                            Descricao = "Vacina BCG",
                            Sigla = "BCG"
                        },
                        new
                        {
                            Id = 16,
                            Codigo = 16,
                            Descricao = "Soro anticrotálico",
                            Sigla = "SACROT"
                        },
                        new
                        {
                            Id = 17,
                            Codigo = 17,
                            Descricao = "Vacina Hib",
                            Sigla = "Hib"
                        },
                        new
                        {
                            Id = 18,
                            Codigo = 18,
                            Descricao = "Vacina raiva embrião de galinha",
                            Sigla = "VR"
                        },
                        new
                        {
                            Id = 19,
                            Codigo = 19,
                            Descricao = "Imunoglobulina humana antivaricela",
                            Sigla = "IGHV"
                        },
                        new
                        {
                            Id = 20,
                            Codigo = 20,
                            Descricao = "Imunoglobulina humana anti-hepatite B",
                            Sigla = "IGHHB"
                        },
                        new
                        {
                            Id = 21,
                            Codigo = 21,
                            Descricao = "Vacina pneumo 23",
                            Sigla = "VPP23"
                        },
                        new
                        {
                            Id = 22,
                            Codigo = 22,
                            Descricao = "Vacina polio injetável",
                            Sigla = "VIP"
                        },
                        new
                        {
                            Id = 23,
                            Codigo = 23,
                            Descricao = "Imunoglobulina humana antirrábica",
                            Sigla = "IGHR"
                        },
                        new
                        {
                            Id = 24,
                            Codigo = 24,
                            Descricao = "Vacina sarampo, caxumba, rubéola",
                            Sigla = "SCR"
                        },
                        new
                        {
                            Id = 25,
                            Codigo = 25,
                            Descricao = "Vacina difteria e tétano adulto",
                            Sigla = "dT"
                        },
                        new
                        {
                            Id = 26,
                            Codigo = 26,
                            Descricao = "Vacina pneumo 10",
                            Sigla = "VPC10"
                        },
                        new
                        {
                            Id = 28,
                            Codigo = 28,
                            Descricao = "Vacina polio oral",
                            Sigla = "VOP"
                        },
                        new
                        {
                            Id = 29,
                            Codigo = 29,
                            Descricao = "Vacina penta acelular (DTPa/VIP/Hib)",
                            Sigla = "PENTA acelular"
                        },
                        new
                        {
                            Id = 30,
                            Codigo = 30,
                            Descricao = "Vacina febre tifóide",
                            Sigla = "FTp"
                        },
                        new
                        {
                            Id = 31,
                            Codigo = 31,
                            Descricao = "Soro antiloxoscélico (trivalente)",
                            Sigla = "SALOXO"
                        },
                        new
                        {
                            Id = 32,
                            Codigo = 32,
                            Descricao = "Soro antilonômico",
                            Sigla = "SALONO"
                        },
                        new
                        {
                            Id = 33,
                            Codigo = 33,
                            Descricao = "Vacina influenza trivalente",
                            Sigla = "INF3"
                        },
                        new
                        {
                            Id = 34,
                            Codigo = 34,
                            Descricao = "Vacina varicela",
                            Sigla = "VAR"
                        },
                        new
                        {
                            Id = 35,
                            Codigo = 35,
                            Descricao = "Vacina hepatite A",
                            Sigla = "HA"
                        },
                        new
                        {
                            Id = 36,
                            Codigo = 36,
                            Descricao = "Vacina sarampo, rubéola",
                            Sigla = "SR"
                        },
                        new
                        {
                            Id = 37,
                            Codigo = 37,
                            Descricao = "Vacina raiva em cultivo celular vero",
                            Sigla = "Vero"
                        },
                        new
                        {
                            Id = 38,
                            Codigo = 38,
                            Descricao = "Soro antibotulínico (trivalente)",
                            Sigla = "SBOTULTRI"
                        },
                        new
                        {
                            Id = 39,
                            Codigo = 39,
                            Descricao = "Vacina DTP/Hib",
                            Sigla = "Tetra"
                        },
                        new
                        {
                            Id = 40,
                            Codigo = 40,
                            Descricao = "Vacina pneumocócica 7V",
                            Sigla = "Pncc7V"
                        },
                        new
                        {
                            Id = 41,
                            Codigo = 41,
                            Descricao = "Vacina meningo C",
                            Sigla = "MenC"
                        },
                        new
                        {
                            Id = 42,
                            Codigo = 42,
                            Descricao = "Vacina penta (DTP/HepB/Hib)",
                            Sigla = "PENTA"
                        },
                        new
                        {
                            Id = 43,
                            Codigo = 43,
                            Descricao = "Vacina hexa (DTPa/HepB/VIP/Hib)",
                            Sigla = "HEXA"
                        },
                        new
                        {
                            Id = 44,
                            Codigo = 44,
                            Descricao = "Vacina Influenza H1N1",
                            Sigla = "H1N1"
                        },
                        new
                        {
                            Id = 45,
                            Codigo = 45,
                            Descricao = "Vacina rotavírus",
                            Sigla = "ROTA"
                        },
                        new
                        {
                            Id = 46,
                            Codigo = 46,
                            Descricao = "Vacina DTP",
                            Sigla = "DTP"
                        },
                        new
                        {
                            Id = 47,
                            Codigo = 47,
                            Descricao = "Vacina DTPa infantil",
                            Sigla = "DTPa"
                        },
                        new
                        {
                            Id = 51,
                            Codigo = 51,
                            Descricao = "Vacina febre tifóide (atenuada)",
                            Sigla = "Fta"
                        },
                        new
                        {
                            Id = 55,
                            Codigo = 55,
                            Descricao = "Vacina hepatite A infantil",
                            Sigla = "HepAinf"
                        },
                        new
                        {
                            Id = 56,
                            Codigo = 56,
                            Descricao = "Vacina sarampo, caxumba, rubéola e varicela",
                            Sigla = "SCRV"
                        },
                        new
                        {
                            Id = 57,
                            Codigo = 57,
                            Descricao = "Vacina dTpa adulto",
                            Sigla = "dTpa"
                        },
                        new
                        {
                            Id = 58,
                            Codigo = 58,
                            Descricao = "Vacina DTPa/VIP",
                            Sigla = "TETRA acelular"
                        },
                        new
                        {
                            Id = 59,
                            Codigo = 59,
                            Descricao = "Vacina pneumo 13",
                            Sigla = "VPC13"
                        },
                        new
                        {
                            Id = 60,
                            Codigo = 60,
                            Descricao = "Vacina HPV bivalente",
                            Sigla = "HPV2"
                        },
                        new
                        {
                            Id = 61,
                            Codigo = 61,
                            Descricao = "Vacina toxóide tetânico",
                            Sigla = "TT"
                        },
                        new
                        {
                            Id = 62,
                            Codigo = 62,
                            Descricao = "Hepatite AeB(pediátrica)",
                            Sigla = "HAeHBped"
                        },
                        new
                        {
                            Id = 63,
                            Codigo = 63,
                            Descricao = "Vacina hepatite AeB(uso adulto)",
                            Sigla = "HAeHB"
                        },
                        new
                        {
                            Id = 64,
                            Codigo = 64,
                            Descricao = "Vacina influenza ID",
                            Sigla = "FLU ID"
                        },
                        new
                        {
                            Id = 65,
                            Codigo = 65,
                            Descricao = "Vacina rotavírus pentavalente",
                            Sigla = "ROTA5"
                        },
                        new
                        {
                            Id = 66,
                            Codigo = 66,
                            Descricao = "Vacina meningocócica B/C",
                            Sigla = "MEN BC"
                        },
                        new
                        {
                            Id = 67,
                            Codigo = 67,
                            Descricao = "Vacina HPV quadrivalente",
                            Sigla = "HPV4"
                        },
                        new
                        {
                            Id = 69,
                            Codigo = 69,
                            Descricao = "Soro antibotulínico AB (bivalente)",
                            Sigla = "SABOT"
                        },
                        new
                        {
                            Id = 70,
                            Codigo = 70,
                            Descricao = "Vacina sarampo",
                            Sigla = "Sarampo"
                        },
                        new
                        {
                            Id = 71,
                            Codigo = 71,
                            Descricao = "Vacina rubéola",
                            Sigla = "Rubeola"
                        },
                        new
                        {
                            Id = 72,
                            Codigo = 72,
                            Descricao = "Vacina gripe",
                            Sigla = "Gripe Sazonal"
                        },
                        new
                        {
                            Id = 73,
                            Codigo = 73,
                            Descricao = "Vacina quádrupla viral",
                            Sigla = "Quadrupla Viral"
                        },
                        new
                        {
                            Id = 74,
                            Codigo = 74,
                            Descricao = "Vacina meningo ACWY",
                            Sigla = "MenACWY"
                        },
                        new
                        {
                            Id = 75,
                            Codigo = 75,
                            Descricao = "Vacina cólera",
                            Sigla = "COLERA"
                        },
                        new
                        {
                            Id = 76,
                            Codigo = 76,
                            Descricao = "Vacina herpes-zóster",
                            Sigla = "VHZ"
                        },
                        new
                        {
                            Id = 77,
                            Codigo = 77,
                            Descricao = "Vacina influenza tetravalente",
                            Sigla = "INF4"
                        },
                        new
                        {
                            Id = 78,
                            Codigo = 78,
                            Descricao = "Vacina meningo B",
                            Sigla = "MenB"
                        },
                        new
                        {
                            Id = 82,
                            Codigo = 82,
                            Descricao = "Vacina dengue",
                            Sigla = "Dengue"
                        },
                        new
                        {
                            Id = 83,
                            Codigo = 83,
                            Descricao = "Vacina hepatite A adulto",
                            Sigla = "HEPAad"
                        },
                        new
                        {
                            Id = 84,
                            Codigo = 84,
                            Descricao = "Vacina febre amarela fracionada",
                            Sigla = "VFA-F"
                        },
                        new
                        {
                            Id = 85,
                            Codigo = 85,
                            Descricao = "Vacina COVID-19-recombinante, AstraZeneca/Fiocruz (Covishield)",
                            Sigla = "COVID-19 ASTRAZENECA/FIOCRUZ - COVISHIELD"
                        },
                        new
                        {
                            Id = 86,
                            Codigo = 86,
                            Descricao = "Vacina COVID-19-inativada, Sinovac/Butantan (Coronavac)",
                            Sigla = "COVID-19 SINOVAC/BUTANTAN - CORONAVAC"
                        },
                        new
                        {
                            Id = 87,
                            Codigo = 87,
                            Descricao = "Vacina COVID-19-RNAm, Pfizer (Comirnaty)",
                            Sigla = "COVID-19 PFIZER - COMIRNATY"
                        },
                        new
                        {
                            Id = 88,
                            Codigo = 88,
                            Descricao = "Vacina COVID-19-recombinante, Janssen (Ad26.COV2.S)",
                            Sigla = "COVID-19 JANSSEN - Ad26.COV2.S"
                        },
                        new
                        {
                            Id = 89,
                            Codigo = 89,
                            Descricao = "Vacina COVID-19-recombinante, AstraZeneca/Covax (ChAdOx1-S)",
                            Sigla = "COVID-19 ASTRAZENECA - ChAdOx1-S"
                        },
                        new
                        {
                            Id = 97,
                            Codigo = 97,
                            Descricao = "vacina COVID-19-RNAm, Moderna (Spikevax)",
                            Sigla = "COVID-19 MODERNA - SPIKEVAX"
                        },
                        new
                        {
                            Id = 98,
                            Codigo = 98,
                            Descricao = "Vacina COVID-19-inativada, Sinovac (Coronavac)",
                            Sigla = "COVID-19 SINOVAC - CORONAVAC"
                        },
                        new
                        {
                            Id = 99,
                            Codigo = 99,
                            Descricao = "Vacina COVID-19-RNAm, Pfizer (Comirnaty) pediátrica",
                            Sigla = "COVID-19 PFIZER - COMIRNATY PEDIÁTRICA"
                        },
                        new
                        {
                            Id = 100,
                            Codigo = 100,
                            Descricao = "Vacina Varíola Bavarian Nordic",
                            Sigla = "VVBN"
                        },
                        new
                        {
                            Id = 101,
                            Codigo = 101,
                            Descricao = "Vacina Herpes-Zoster (recombinante)",
                            Sigla = "VZR"
                        },
                        new
                        {
                            Id = 102,
                            Codigo = 102,
                            Descricao = "Vacina COVID-19-RNAm, Pfizer (Comirnaty) pediátrica menor de 5 anos",
                            Sigla = "COVID-19 PFIZER - COMIRNATY PEDIÁTRICA MENOR DE 5 ANOS"
                        },
                        new
                        {
                            Id = 103,
                            Codigo = 103,
                            Descricao = "Vacina COVID-19-RNAm, Pfizer (Comirnaty) bivalente",
                            Sigla = "COVID-19 PFIZER - COMIRNATY BIVALENTE"
                        },
                        new
                        {
                            Id = 104,
                            Codigo = 104,
                            Descricao = "Vacina dengue (atenuada)",
                            Sigla = "DNG"
                        },
                        new
                        {
                            Id = 105,
                            Codigo = 105,
                            Descricao = "Vacina Covid-19-RNAm, Moderna (Spikevax) bivalente",
                            Sigla = "COVID-19 MODERNA - SPIKEVAX BIVALENTE"
                        },
                        new
                        {
                            Id = 106,
                            Codigo = 106,
                            Descricao = "Vacina adsorvida pneumocócica 15-valente (conjugada, polissacarídica)",
                            Sigla = "VPC15"
                        });
                });

            modelBuilder.Entity("VacineMais.API.Models.Membro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("TEXT");

                    b.Property<int>("FamiliaId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FamiliaId");

                    b.ToTable("Membro");
                });

            modelBuilder.Entity("VacineMais.API.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Ativo")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("VacineMais.API.Models.Familia", b =>
                {
                    b.HasOne("VacineMais.API.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("VacineMais.API.Models.Membro", b =>
                {
                    b.HasOne("VacineMais.API.Models.Familia", "Familia")
                        .WithMany("Membros")
                        .HasForeignKey("FamiliaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Familia");
                });

            modelBuilder.Entity("VacineMais.API.Models.Familia", b =>
                {
                    b.Navigation("Membros");
                });
#pragma warning restore 612, 618
        }
    }
}
