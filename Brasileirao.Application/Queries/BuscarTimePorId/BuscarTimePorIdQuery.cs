using Brasileirao.Application.Models.ViewModels;
using MediatR;

namespace Brasileirao.Application.Queries.BuscarTimePorId;

public class BuscarTimePorIdQuery : IRequest<TimesDetalhesViewModel>
{
    public Guid Id { get; private set; }

    public BuscarTimePorIdQuery(Guid id)
    {
        Id = id;
    }
}