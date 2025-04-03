using Brasileirao.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Brasileirao.Infrastructure.Configuration;

public class TimeConfiguration : IEntityTypeConfiguration<Time>
{
    public void Configure(EntityTypeBuilder<Time> builder)
    {
        builder
            .HasKey(t => t.Id);
        
        builder
            .HasMany(t => t.CampeonatoTimes)
            .WithOne(ct => ct.Time)
            .HasForeignKey(ct => ct.TimeId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder
            .Property(t => t.Nome)
            .HasMaxLength(100)
            .IsRequired();
        
        builder
            .Property(t => t.Estado)
            .HasMaxLength(100)
            .IsRequired();
        
    }
}