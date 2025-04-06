using System.Collections;
using Brasileirao.Domain.Enums;

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
    public ICollection<RegistroDeGols> Gols { get; private set; } =  new List<RegistroDeGols>();
    public ICollection<EventoPartida> Eventos { get; private set; } = new List<EventoPartida>();
    
    protected Partida(){}

    public Partida(DateTime dataDaPartida, Guid campeonatoId, Guid timeMandanteId, Guid timeVisitanteId)
    {
        DataDaPartida = dataDaPartida;
        CampeonatoId = campeonatoId;
        TimeMandanteId = timeMandanteId;
        TimeVisitanteId = timeVisitanteId;
        PlacarMandante = 0;
        PlacarVisitante = 0;
    }

    public void AdicionarGol(Guid jogadorId, Guid timeId, int minuto)
    {
        var gol = new RegistroDeGols(jogadorId, timeId, minuto);
        gol.SetPartidaId(Id);
        Gols.Add(gol);
    }

    public void AdicionarEvento(Guid jogadorId, Guid timeId, int minuto, TipoEventoPartidaEnum tipoEventoPartidaEnum)
    {
        var evento = new EventoPartida(jogadorId, timeId, minuto, tipoEventoPartidaEnum);
        evento.SetPartidaId(Id);
        Eventos.Add(evento);
    }
   
}