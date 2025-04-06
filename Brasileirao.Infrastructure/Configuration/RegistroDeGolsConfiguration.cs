using Brasileirao.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Brasileirao.Infrastructure.Configuration;

public class RegistroDeGolsConfiguration : IEntityTypeConfiguration<RegistroDeGols>
{
    public void Configure(EntityTypeBuilder<RegistroDeGols> builder)
    {
        builder
            .HasKey(g => g.Id);
        
        builder
            .HasOne(g => g.Partida)
            .WithMany(p => p.Gols)
            .HasForeignKey(g => g.PartidaId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder
            .HasOne(g => g.Jogador)
            .WithMany(j => j.Gols)
            .HasForeignKey(g => g.JogadorId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder
            .HasOne(g => g.Time)
            .WithMany(t => t.GolsMarcados)
            .HasForeignKey(g => g.TimeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .Property(g => g.GolMinuto)
            .IsRequired();

    }
}