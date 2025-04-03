using MediatR;

namespace Brasileirao.Application.Commands.AtualizarCampeonatoTime;

public class AtualizarCampeonatoTimeCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
    public Guid CampeonatoId { get; set; }
    public Guid TimeId { get; set; }
}