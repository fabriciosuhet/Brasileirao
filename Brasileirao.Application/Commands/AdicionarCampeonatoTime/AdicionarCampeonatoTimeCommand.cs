using MediatR;

namespace Brasileirao.Application.Commands.AdicionarCampeonatoTime;

public class AdicionarCampeonatoTimeCommand : IRequest<Guid>
{
    public Guid CampeonatoId { get;  set; }
    public Guid TimeId { get;  set; }
}