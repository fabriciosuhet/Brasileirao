using Brasileirao.Domain.Entities;
using Brasileirao.Domain.Repositories;
using MediatR;

namespace Brasileirao.Application.Commands.AdicionarTime;

public class AdicionarTimeCommandHandler : IRequestHandler<AdicionarTimeCommand, Guid>
{
    private readonly IRepository<Time> _timeRepository;

    public AdicionarTimeCommandHandler(IRepository<Time> timeRepository)
    {
        _timeRepository = timeRepository;
    }

    public async Task<Guid> Handle(AdicionarTimeCommand request, CancellationToken cancellationToken)
    {
        var time = new Time(request.Nome, request.Estado);
        await _timeRepository.CreateAsync(time);
        return time.Id;
    }
}