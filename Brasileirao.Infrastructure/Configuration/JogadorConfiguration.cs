using Brasileirao.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Brasileirao.Infrastructure.Configuration;

public class JogadorConfiguration : IEntityTypeConfiguration<Jogador>
{
    public void Configure(EntityTypeBuilder<Jogador> builder)
    {
        builder
            .HasKey(j => j.Id);
        
        builder
            .HasOne(j => j.Time)
            .WithMany(t => t.Jogadores)
            .HasForeignKey(j => j.TimeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .Property(j => j.Nome)
            .HasMaxLength(100)
            .IsRequired();

        builder
            .Property(j => j.Posicao)
            .HasMaxLength(100)
            .IsRequired();

        builder
            .Property(j => j.DataNascimento)
            .IsRequired();

        builder
            .Property(j => j.NumeroCamisa)
            .HasMaxLength(3)
            .IsRequired();
    }
}