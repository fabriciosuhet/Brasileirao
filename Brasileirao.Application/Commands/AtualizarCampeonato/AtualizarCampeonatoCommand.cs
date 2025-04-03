using MediatR;

namespace Brasileirao.Application.Commands.AtualizarCampeonato;

public class AtualizarCampeonatoCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
}