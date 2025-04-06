using Brasileirao.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Brasileirao.Infrastructure.Configuration;

public class EventoPartidaConfiguration : IEntityTypeConfiguration<EventoPartida>
{
    public void Configure(EntityTypeBuilder<EventoPartida> builder)
    {
        builder
            .HasKey(ep => ep.Id);
        
        builder
            .HasOne(ep => ep.Partida)
            .WithMany(p => p.Eventos)
            .HasForeignKey(ep => ep.PartidaId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder
            .HasOne(ep => ep.Jogador)
            .WithMany(j => j.Eventos)
            .HasForeignKey(ep => ep.JogadorId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder
            .HasOne(ep => ep.Time)
            .WithMany(t => t.Eventos)
            .HasForeignKey(ep => ep.TimeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}