using Brasileirao.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Brasileirao.Infrastructure.Configuration;

public class TituloConfiguration : IEntityTypeConfiguration<Titulo>
{
    public void Configure(EntityTypeBuilder<Titulo> builder)
    {
        builder
            .HasKey(t => t.Id);
        
        builder
            .HasMany(t => t.Times)
            .WithOne(tt => tt.Titulo)
            .HasForeignKey(tt => tt.TituloId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder
            .Property(t => t.Nome)
            .HasMaxLength(100)
            .IsRequired();
        
        builder
            .Property(t => t.DataTituto)
            .IsRequired();
        
        builder
            .HasMany(t => t.Jogadores)
            .WithOne(jt => jt.Titulo)
            .HasForeignKey(jt => jt.TituloId)
            .OnDelete(DeleteBehavior.Restrict);

    }
}