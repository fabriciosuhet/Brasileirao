using MediatR;

namespace Brasileirao.Application.Commands.AtualizarTimeTitulo;

public class AtualizarTimeTituloCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
    public Guid TimeId { get; set; }
    public Guid TituloId { get; set; }
    public int Quantidade { get; set; }
    
}