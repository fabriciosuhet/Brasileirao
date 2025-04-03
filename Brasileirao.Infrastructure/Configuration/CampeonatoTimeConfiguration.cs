using Brasileirao.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Brasileirao.Infrastructure.Configuration;

public class CampeonatoTimeConfiguration : IEntityTypeConfiguration<CampeonatoTime>
{
    public void Configure(EntityTypeBuilder<CampeonatoTime> builder)
    {
        builder.HasKey(ct => new { ct.CampeonatoId, ct.TimeId });
        
        builder
            .HasOne(ct => ct.Campeonato)
            .WithMany(c => c.CampeonatoTimes)
            .HasForeignKey(ct => ct.CampeonatoId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(ct => ct.Time)
            .WithMany(t => t.CampeonatoTimes)
            .HasForeignKey(ct => ct.TimeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}