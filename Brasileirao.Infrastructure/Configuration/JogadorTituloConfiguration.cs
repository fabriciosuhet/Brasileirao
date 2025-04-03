using Brasileirao.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Brasileirao.Infrastructure.Configuration;

public class JogadorTituloConfiguration : IEntityTypeConfiguration<JogadorTitulo>
{
    public void Configure(EntityTypeBuilder<JogadorTitulo> builder)
    {
        builder.HasKey(jt => new { jt.JogadorId, jt.TituloId });

        builder
            .HasOne(jt => jt.Jogador)
            .WithMany(j => j.Titulos)
            .HasForeignKey(jt => jt.JogadorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(jt => jt.Titulo)
            .WithMany(t => t.Jogadores)
            .HasForeignKey(jt => jt.TituloId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}