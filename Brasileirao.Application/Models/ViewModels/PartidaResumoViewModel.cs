namespace Brasileirao.Application.Models.ViewModels;

public class PartidaResumoViewModel
{
    public Guid Id { get; set; }
    public DateTime Data { get; set; }
    public string NomeCampeonato { get; set; }
    public string TimeMandante { get; set; }
    public int PlacarMandante { get; set; }
    public string TimeVisitante { get; set; }
    public int PlacarVisitante { get; set; }

    public PartidaResumoViewModel(Guid id, DateTime data, string nomeCampeonato, string timeMandante, int placarMandante, string timeVisitante, int placarVisitante)
    {
        Id = id;
        Data = data;
        NomeCampeonato = nomeCampeonato;
        TimeMandante = timeMandante;
        PlacarMandante = placarMandante;
        TimeVisitante = timeVisitante;
        PlacarVisitante = placarVisitante;
    }
}