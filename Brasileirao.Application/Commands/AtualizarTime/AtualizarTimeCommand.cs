using MediatR;

namespace Brasileirao.Application.Commands.AtualizarTime;

public class AtualizarTimeCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
}