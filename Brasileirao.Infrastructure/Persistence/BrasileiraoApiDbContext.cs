using System.Reflection;
using Brasileirao.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Brasileirao.Infrastructure.Persistence;

public class BrasileiraoApiDbContext : DbContext
{
    public BrasileiraoApiDbContext(DbContextOptions<BrasileiraoApiDbContext> options) : base(options) { }
    
    protected BrasileiraoApiDbContext(){}
    
    public DbSet<Campeonato> Campeonatos { get; set; }
    public DbSet<Jogador> Jogadores { get; set; }
    public DbSet<Time> Times { get; set; }
    public DbSet<Titulo> Titulos { get; set; }
    public DbSet<JogadorTitulo> TitulosJogador { get; set; }
    public DbSet<TimeTitulo> TitulosTime { get; set; }
    public DbSet<CampeonatoTime> CampeonatosTime { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}