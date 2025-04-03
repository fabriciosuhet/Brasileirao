using MediatR;

namespace Brasileirao.Application.Commands.AtualizarJogador;

public class AtualizarJogadorCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
    public string Posicao { get; set; }
    public string NumeroCamisa { get; set; }
}