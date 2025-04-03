namespace Brasileirao.Domain.Entities;

public class Gol : BaseEntity
{
    public Guid PartidaId { get; private set; }
    public Partida Partida { get; private set; }
    public Guid JogadorId { get; private set; }
    public Jogador Jogador { get; private set; }
    public Guid TimeId { get; private set; }
    public Time Time { get; private set; }
    public int GolMinuto { get; private set; }

    public Gol(Guid partidaId, Guid jogadorId, Guid timeId, int golMinuto)
    {
        PartidaId = partidaId;
        JogadorId = jogadorId;
        TimeId = timeId;
        GolMinuto = golMinuto;
    }
}