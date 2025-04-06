namespace Brasileirao.Application.Models.ViewModels;

public class TimesDetalhesViewModel
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Estado { get; set; }
    public IEnumerable<JogadorViewModel> Jogadores { get; set; }
    public IEnumerable<TituloTimeViewModel> Titulos { get; set; }
    public IEnumerable<CampeonatoViewModel> Campeonatos { get; set; }
    public IEnumerable<PartidaResumoViewModel> PartidasComoMandante { get; set; }
    public IEnumerable<PartidaResumoViewModel> PartidasComoVisitante { get; set; }
    public IEnumerable<RegistroDeGolsViewModel> GolsMarcados { get; set; }
    public IEnumerable<EventoPartidaViewModel> Eventos { get; set; }

    public TimesDetalhesViewModel(Guid id, string nome, string estado, IEnumerable<JogadorViewModel> jogadores, IEnumerable<TituloTimeViewModel> titulos, IEnumerable<CampeonatoViewModel> campeonatos, IEnumerable<PartidaResumoViewModel> partidasComoMandante, IEnumerable<PartidaResumoViewModel> partidasComoVisitante, IEnumerable<RegistroDeGolsViewModel> golsMarcados, IEnumerable<EventoPartidaViewModel> eventos)
    {
        Id = id;
        Nome = nome;
        Estado = estado;
        Jogadores = jogadores;
        Titulos = titulos;
        Campeonatos = campeonatos;
        PartidasComoMandante = partidasComoMandante;
        PartidasComoVisitante = partidasComoVisitante;
        GolsMarcados = golsMarcados;
        Eventos = eventos;
    }
}