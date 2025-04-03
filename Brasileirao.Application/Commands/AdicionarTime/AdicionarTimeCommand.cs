using MediatR;

namespace Brasileirao.Application.Commands.AdicionarTime;

public class AdicionarTimeCommand : IRequest<Guid>
{
    public string Nome { get; set; }
    public string Estado { get; set; }
}