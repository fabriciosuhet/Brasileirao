using MediatR;

namespace Brasileirao.Application.Commands.AdicionarCampeonato;

public class AdicionarCampeonatoCommand : IRequest<Guid>
{
    public string Nome { get; set; }
    public int Ano { get; set; }
}