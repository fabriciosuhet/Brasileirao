using Brasileirao.Domain.Enums;

namespace Brasileirao.Domain.Entities;

public class EventoPartida : BaseEntity
{
    public Guid PartidaId { get; private set; }
    public Partida Partida { get; private set; }

    public Guid? JogadorId { get; private set; }
    public Jogador? Jogador { get; private set; }

    public Guid TimeId { get; private set; }
    public Time Time { get; private set; }

    public int Minuto { get; private set; }
    
    public TipoEventoPartidaEnum TipoEvento { get; private set; } = TipoEventoPartidaEnum.InicioDoJogo;
    
    protected EventoPartida(){}

    public EventoPartida(Guid partidaId, Guid? jogadorId, Guid timeId, int minuto)
    {
        PartidaId = partidaId;
        JogadorId = jogadorId;
        TimeId = timeId;
        Minuto = minuto;
    }

    public EventoPartida(Guid? jogadorId, Guid timeId, int minuto, TipoEventoPartidaEnum tipoEvento)
    {
        JogadorId = jogadorId;
        TimeId = timeId;
        Minuto = minuto;
        TipoEvento = tipoEvento;
    }

    public void SetPartidaId(Guid partidaId) => PartidaId = partidaId;
    
}