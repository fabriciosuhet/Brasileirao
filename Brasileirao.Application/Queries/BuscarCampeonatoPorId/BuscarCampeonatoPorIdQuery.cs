using Brasileirao.Application.Models.ViewModels;
using MediatR;

namespace Brasileirao.Application.Queries.BuscarCampeonatoPorId;

public class BuscarCampeonatoPorIdQuery : IRequest<CampeonatoDetalhesViewModel>
{
    public Guid Id { get; private set; }

    public BuscarCampeonatoPorIdQuery(Guid id)
    {
        Id = id;
    }
}