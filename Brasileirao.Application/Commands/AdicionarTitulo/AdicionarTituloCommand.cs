using MediatR;

namespace Brasileirao.Application.Commands.AdicionarTitulo;

public class AdicionarTituloCommand : IRequest<Guid>
{
    public string Nome { get; set; }
    public DateTime DataTitulo { get; set; }
}