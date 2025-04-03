using Brasileirao.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Brasileirao.Infrastructure.Configuration;

public class TimeTituloConfiguration : IEntityTypeConfiguration<TimeTitulo>
{
    public void Configure(EntityTypeBuilder<TimeTitulo> builder)
    {
        builder.HasKey(tt => new { tt.TituloId, tt.TimeId });
        
        builder
            .HasOne(tt => tt.Time)
            .WithMany(t => t.Titulos)
            .HasForeignKey(tt => tt.TimeId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder
            .HasOne(tt => tt.Titulo)
            .WithMany(t => t.Times)
            .HasForeignKey(tt => tt.TituloId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}