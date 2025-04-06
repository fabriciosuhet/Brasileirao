namespace Brasileirao.Application.Models.ViewModels;

public class PartidaViewModel
{
    public DateTime DataDaPartida { get; set; }
    public string NomeCampeonato { get; set; }
    public string TimeMandante { get; set; }
    public int PlacarMandante { get; private set; }
    public string TimeVisitante { get; set; }
    public int PlacarVisitante { get; private set; }

    public PartidaViewModel(DateTime dataDaPartida, string nomeCampeonato, string timeMandante, int placarMandante, string timeVisitante, int placarVisitante)
    {
        DataDaPartida = dataDaPartida;
        NomeCampeonato = nomeCampeonato;
        TimeMandante = timeMandante;
        PlacarMandante = placarMandante;
        TimeVisitante = timeVisitante;
        PlacarVisitante = placarVisitante;
    }
}