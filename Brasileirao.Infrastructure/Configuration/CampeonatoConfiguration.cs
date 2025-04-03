using Brasileirao.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Brasileirao.Infrastructure.Configuration;

public class CampeonatoConfiguration : IEntityTypeConfiguration<Campeonato>
{
    public void Configure(EntityTypeBuilder<Campeonato> builder)
    {
        builder
            .HasKey(c => c.Id);

        builder
            .HasMany(c => c.CampeonatoTimes)
            .WithOne(ct => ct.Campeonato)
            .HasForeignKey(ct => ct.CampeonatoId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .Property(c => c.Nome)
            .HasMaxLength(255)
            .IsRequired();

        builder
            .Property(c => c.Ano)
            .IsRequired();
        
    }
}