using MediatR;

namespace Brasileirao.Application.Commands.AdicionarJogador;

public class AdicionarJogadorCommand : IRequest<Guid>
{
    public string Nome { get; set; }
    public string Posicao { get; set; }
    public DateTime DataNascimento { get; set; }
    public string NumeroCamisa { get; set; }
    public Guid TimeId { get; set; }
}