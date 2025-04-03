namespace Brasileirao.Application.Models.ViewModels;

public class TimesDetalhesViewModel
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Estado { get; set; }
    public IEnumerable<JogadorViewModel> Jogadores { get; set; }
    public IEnumerable<TituloTimeViewModel> Titulos { get; set; }
    public IEnumerable<CampeonatoViewModel> Campeonatos { get; set; }

    public TimesDetalhesViewModel(Guid id, string nome, string estado, IEnumerable<JogadorViewModel> jogadores, IEnumerable<TituloTimeViewModel> titulos, IEnumerable<CampeonatoViewModel> campeonatos)
    {
        Id = id;
        Nome = nome;
        Estado = estado;
        Jogadores = jogadores;
        Titulos = titulos;
        Campeonatos = campeonatos;
    }
}