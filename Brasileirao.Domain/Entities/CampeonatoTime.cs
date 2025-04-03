namespace Brasileirao.Domain.Entities;

public class CampeonatoTime : BaseEntity
{
    public Guid CampeonatoId { get; private set; }
    public Campeonato Campeonato { get; private set; }

    public Guid TimeId { get; private set; }
    public Time Time { get; private set; }
    
    protected CampeonatoTime() { }

    public CampeonatoTime(Guid campeonatoId, Guid timeId)
    {
        CampeonatoId = campeonatoId;
        TimeId = timeId;
    }

    public void AtualizarCampeonatoTime(Guid campeonatoId, Guid timeId)
    {
        CampeonatoId = campeonatoId;
        TimeId = timeId;
    }
}