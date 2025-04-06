using Brasileirao.Domain.Enums;
using MediatR;

namespace Brasileirao.Application.Commands.AdicionarEvento;

public class AdicionarEventoCommand : IRequest<Guid>
{
    public Guid PartidaId { get; set; }
    public TipoEventoPartidaEnum TipoEvento { get; set; }
    public Guid JogadorId { get; set; }
    public Guid TimeId { get; set; }
    public int Minuto { get; set; }

    public AdicionarEventoCommand(Guid partidaId, TipoEventoPartidaEnum tipoEvento, Guid jogadorId, Guid timeId, int minuto)
    {
        PartidaId = partidaId;
        TipoEvento = tipoEvento;
        JogadorId = jogadorId;
        TimeId = timeId;
        Minuto = minuto;
    }
}