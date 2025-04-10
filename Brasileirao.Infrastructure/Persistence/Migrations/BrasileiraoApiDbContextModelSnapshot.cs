﻿// <auto-generated />
using System;
using Brasileirao.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Brasileirao.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(BrasileiraoApiDbContext))]
    partial class BrasileiraoApiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Brasileirao.Domain.Entities.Campeonato", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("Ano")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Campeonatos");
                });

            modelBuilder.Entity("Brasileirao.Domain.Entities.CampeonatoTime", b =>
                {
                    b.Property<Guid>("CampeonatoId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("TimeId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("Id")
                        .HasColumnType("char(36)");

                    b.HasKey("CampeonatoId", "TimeId");

                    b.HasIndex("TimeId");

                    b.ToTable("CampeonatosTime");
                });

            modelBuilder.Entity("Brasileirao.Domain.Entities.EventoPartida", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("JogadorId")
                        .HasColumnType("char(36)");

                    b.Property<int>("Minuto")
                        .HasColumnType("int");

                    b.Property<Guid>("PartidaId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("TimeId")
                        .HasColumnType("char(36)");

                    b.Property<int>("TipoEvento")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("JogadorId");

                    b.HasIndex("PartidaId");

                    b.HasIndex("TimeId");

                    b.ToTable("Eventos");
                });

            modelBuilder.Entity("Brasileirao.Domain.Entities.Jogador", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("NumeroCamisa")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("varchar(3)");

                    b.Property<string>("Posicao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<Guid>("TimeId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("TimeId");

                    b.ToTable("Jogadores");
                });

            modelBuilder.Entity("Brasileirao.Domain.Entities.JogadorTitulo", b =>
                {
                    b.Property<Guid>("JogadorId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("TituloId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("Id")
                        .HasColumnType("char(36)");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("JogadorId", "TituloId");

                    b.HasIndex("TituloId");

                    b.ToTable("TitulosJogador");
                });

            modelBuilder.Entity("Brasileirao.Domain.Entities.Partida", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CampeonatoId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("DataDaPartida")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("PlacarMandante")
                        .HasColumnType("int");

                    b.Property<int>("PlacarVisitante")
                        .HasColumnType("int");

                    b.Property<Guid>("TimeMandanteId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("TimeVisitanteId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("CampeonatoId");

                    b.HasIndex("TimeMandanteId");

                    b.HasIndex("TimeVisitanteId");

                    b.ToTable("Partidas");
                });

            modelBuilder.Entity("Brasileirao.Domain.Entities.RegistroDeGols", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("GolMinuto")
                        .HasColumnType("int");

                    b.Property<Guid>("JogadorId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("PartidaId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("TimeId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("JogadorId");

                    b.HasIndex("PartidaId");

                    b.HasIndex("TimeId");

                    b.ToTable("Gols");
                });

            modelBuilder.Entity("Brasileirao.Domain.Entities.Time", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Times");
                });

            modelBuilder.Entity("Brasileirao.Domain.Entities.TimeTitulo", b =>
                {
                    b.Property<Guid>("TituloId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("TimeId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("Id")
                        .HasColumnType("char(36)");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("TituloId", "TimeId");

                    b.HasIndex("TimeId");

                    b.ToTable("TitulosTime");
                });

            modelBuilder.Entity("Brasileirao.Domain.Entities.Titulo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("DataTituto")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Titulos");
                });

            modelBuilder.Entity("Brasileirao.Domain.Entities.CampeonatoTime", b =>
                {
                    b.HasOne("Brasileirao.Domain.Entities.Campeonato", "Campeonato")
                        .WithMany("CampeonatoTimes")
                        .HasForeignKey("CampeonatoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Brasileirao.Domain.Entities.Time", "Time")
                        .WithMany("CampeonatoTimes")
                        .HasForeignKey("TimeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Campeonato");

                    b.Navigation("Time");
                });

            modelBuilder.Entity("Brasileirao.Domain.Entities.EventoPartida", b =>
                {
                    b.HasOne("Brasileirao.Domain.Entities.Jogador", "Jogador")
                        .WithMany("Eventos")
                        .HasForeignKey("JogadorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Brasileirao.Domain.Entities.Partida", "Partida")
                        .WithMany("Eventos")
                        .HasForeignKey("PartidaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Brasileirao.Domain.Entities.Time", "Time")
                        .WithMany("Eventos")
                        .HasForeignKey("TimeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Jogador");

                    b.Navigation("Partida");

                    b.Navigation("Time");
                });

            modelBuilder.Entity("Brasileirao.Domain.Entities.Jogador", b =>
                {
                    b.HasOne("Brasileirao.Domain.Entities.Time", "Time")
                        .WithMany("Jogadores")
                        .HasForeignKey("TimeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Time");
                });

            modelBuilder.Entity("Brasileirao.Domain.Entities.JogadorTitulo", b =>
                {
                    b.HasOne("Brasileirao.Domain.Entities.Jogador", "Jogador")
                        .WithMany("Titulos")
                        .HasForeignKey("JogadorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Brasileirao.Domain.Entities.Titulo", "Titulo")
                        .WithMany("Jogadores")
                        .HasForeignKey("TituloId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Jogador");

                    b.Navigation("Titulo");
                });

            modelBuilder.Entity("Brasileirao.Domain.Entities.Partida", b =>
                {
                    b.HasOne("Brasileirao.Domain.Entities.Campeonato", "Campeonato")
                        .WithMany("Partidas")
                        .HasForeignKey("CampeonatoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Brasileirao.Domain.Entities.Time", "TimeMandante")
                        .WithMany("PartidasComoMandante")
                        .HasForeignKey("TimeMandanteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Brasileirao.Domain.Entities.Time", "TimeVisitante")
                        .WithMany("PartidasComoVisitante")
                        .HasForeignKey("TimeVisitanteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Campeonato");

                    b.Navigation("TimeMandante");

                    b.Navigation("TimeVisitante");
                });

            modelBuilder.Entity("Brasileirao.Domain.Entities.RegistroDeGols", b =>
                {
                    b.HasOne("Brasileirao.Domain.Entities.Jogador", "Jogador")
                        .WithMany("Gols")
                        .HasForeignKey("JogadorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Brasileirao.Domain.Entities.Partida", "Partida")
                        .WithMany("Gols")
                        .HasForeignKey("PartidaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Brasileirao.Domain.Entities.Time", "Time")
                        .WithMany("GolsMarcados")
                        .HasForeignKey("TimeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Jogador");

                    b.Navigation("Partida");

                    b.Navigation("Time");
                });

            modelBuilder.Entity("Brasileirao.Domain.Entities.TimeTitulo", b =>
                {
                    b.HasOne("Brasileirao.Domain.Entities.Time", "Time")
                        .WithMany("Titulos")
                        .HasForeignKey("TimeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Brasileirao.Domain.Entities.Titulo", "Titulo")
                        .WithMany("Times")
                        .HasForeignKey("TituloId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Time");

                    b.Navigation("Titulo");
                });

            modelBuilder.Entity("Brasileirao.Domain.Entities.Campeonato", b =>
                {
                    b.Navigation("CampeonatoTimes");

                    b.Navigation("Partidas");
                });

            modelBuilder.Entity("Brasileirao.Domain.Entities.Jogador", b =>
                {
                    b.Navigation("Eventos");

                    b.Navigation("Gols");

                    b.Navigation("Titulos");
                });

            modelBuilder.Entity("Brasileirao.Domain.Entities.Partida", b =>
                {
                    b.Navigation("Eventos");

                    b.Navigation("Gols");
                });

            modelBuilder.Entity("Brasileirao.Domain.Entities.Time", b =>
                {
                    b.Navigation("CampeonatoTimes");

                    b.Navigation("Eventos");

                    b.Navigation("GolsMarcados");

                    b.Navigation("Jogadores");

                    b.Navigation("PartidasComoMandante");

                    b.Navigation("PartidasComoVisitante");

                    b.Navigation("Titulos");
                });

            modelBuilder.Entity("Brasileirao.Domain.Entities.Titulo", b =>
                {
                    b.Navigation("Jogadores");

                    b.Navigation("Times");
                });
#pragma warning restore 612, 618
        }
    }
}
