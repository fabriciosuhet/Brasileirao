using MediatR;

namespace Brasileirao.Application.Commands.AdicionarJogadorTitulo;

public class AdicionarJogadorTituloCommand : IRequest<Guid>
{
    public Guid JogadorId { get; set; }
    public Guid TituloId { get; set; }
    public int Quantidade { get; set; }
}