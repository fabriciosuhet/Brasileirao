using Brasileirao.Application.Models.ViewModels;
using MediatR;

namespace Brasileirao.Application.Queries.BuscarTituloPorId;

public class BuscarTituloPorIdQuery : IRequest<BuscarTituloDetalhesViewModel>
{
    public Guid Id { get; private set; }

    public BuscarTituloPorIdQuery(Guid id)
    {
        Id = id;
    }
}