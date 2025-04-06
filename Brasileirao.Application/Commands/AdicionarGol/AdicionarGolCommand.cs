using MediatR;

namespace Brasileirao.Application.Commands.AdicionarGol;

public class AdicionarGolCommand : IRequest<Guid>
{
    public Guid PartidaId { get; set; }
    public Guid JogadorId { get; set; }
    public Guid TimeId { get; set; }
    public int GolMinuto { get; set; }

    public AdicionarGolCommand(Guid partidaId, Guid jogadorId, Guid timeId, int golMinuto)
    {
        PartidaId = partidaId;
        JogadorId = jogadorId;
        TimeId = timeId;
        GolMinuto = golMinuto;
    }
}