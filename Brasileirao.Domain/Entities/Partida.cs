namespace Brasileirao.Domain.Entities;

public class Partida : BaseEntity
{
    public DateTime DataDaPartida { get; private set; }
    public Guid CampeonatoId { get; private set; }
    public Campeonato Campeonato { get; private set; }
    public Guid TimeMandanteId { get; private set; }
    public Time TimeMandante { get; private set; }
    public Guid TimeVisitanteId { get; private set; }
    public Time TimeVisitante { get; private set; }
    public int PlacarMandante { get; private set; }
    public int PlacarVisitante { get; private set; }
    
    protected Partida(){}

    public Partida(DateTime dataDaPartida, Guid campeonatoId, Guid timeMandanteId, Guid timeVisitanteId, int placarMandante, int placarVisitante)
    {
        DataDaPartida = dataDaPartida;
        CampeonatoId = campeonatoId;
        TimeMandanteId = timeMandanteId;
        TimeVisitanteId = timeVisitanteId;
        PlacarMandante = placarMandante;
        PlacarVisitante = placarVisitante;
    }
}