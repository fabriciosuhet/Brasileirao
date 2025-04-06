using Brasileirao.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Brasileirao.Infrastructure.Configuration;

public class PartidaConfiguration : IEntityTypeConfiguration<Partida>
{
    public void Configure(EntityTypeBuilder<Partida> builder)
    {
        builder
            .HasKey(p => p.Id);
        
        builder
            .HasOne(p => p.Campeonato)
            .WithMany(c => c.Partidas)
            .HasForeignKey(p => p.CampeonatoId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder
            .HasOne(p => p.TimeMandante)
            .WithMany(t => t.PartidasComoMandante)
            .HasForeignKey(p => p.TimeMandanteId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder
            .HasOne(p => p.TimeVisitante)
            .WithMany(t => t.PartidasComoVisitante)
            .HasForeignKey(p => p.TimeVisitanteId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}