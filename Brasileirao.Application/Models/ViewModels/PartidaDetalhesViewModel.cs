namespace Brasileirao.Application.Models.ViewModels;

public class PartidaDetalhesViewModel
{
    public Guid Id { get; set; }
    public DateTime DataDaPartida { get; set; }
    public string NomeCampeonato { get; set; }
    public string TimeMandante { get; set; }
    public int PlacarMandante { get;  set; }
    public string TimeVisitante { get; set; }
    public int PlacarVisitante { get;  set; }
    public ICollection<EventoPartidaViewModel> Eventos { get; set; }

    public PartidaDetalhesViewModel(Guid id, DateTime dataDaPartida, string nomeCampeonato, string timeMandante, int placarMandante, string timeVisitante, int placarVisitante, ICollection<EventoPartidaViewModel> eventos)
    {
        Id = id;
        DataDaPartida = dataDaPartida;
        NomeCampeonato = nomeCampeonato;
        TimeMandante = timeMandante;
        PlacarMandante = placarMandante;
        TimeVisitante = timeVisitante;
        PlacarVisitante = placarVisitante;
        Eventos = eventos;
    }
}