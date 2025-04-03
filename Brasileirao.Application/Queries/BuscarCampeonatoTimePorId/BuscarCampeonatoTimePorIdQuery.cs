using Brasileirao.Application.Models.ViewModels;
using MediatR;

namespace Brasileirao.Application.Queries.BuscarCampeonatoTimePorId;

public class BuscarCampeonatoTimePorIdQuery : IRequest<CampeonatoTimeDetalhesViewModel>
{
    public Guid Id { get; private set; }

    public BuscarCampeonatoTimePorIdQuery(Guid id)
    {
        Id = id;
    }
}