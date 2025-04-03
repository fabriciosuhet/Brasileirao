using MediatR;

namespace Brasileirao.Application.Commands.AtualizarJogadorTitulo;

public class AtualizarJogadorTituloCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
    public Guid JogadorId { get; set; }
    public Guid TituloId { get; set; }
    public int Quantidade { get; set; }
}