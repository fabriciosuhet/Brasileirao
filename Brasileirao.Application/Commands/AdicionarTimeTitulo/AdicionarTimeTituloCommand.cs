using MediatR;

namespace Brasileirao.Application.Commands.AdicionarTimeTitulo;

public class AdicionarTimeTituloCommand : IRequest<(Guid, Guid)>
{
    public Guid TimeId { get; set; }
    public Guid TituloId { get; set; }
    public int Quantidade { get; set; }
}