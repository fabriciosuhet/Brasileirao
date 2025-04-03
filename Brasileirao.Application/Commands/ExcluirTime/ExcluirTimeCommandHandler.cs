using Brasileirao.Domain.Entities;
using Brasileirao.Domain.Repositories;
using MediatR;

namespace Brasileirao.Application.Commands.ExcluirTime;

public class ExcluirTimeCommandHandler : IRequestHandler<ExcluirTimeCommand, Unit>
{
    private readonly IRepository<Time>  _timeRepository;

    public ExcluirTimeCommandHandler(IRepository<Time> timeRepository)
    {
        _timeRepository = timeRepository;
    }

    public async Task<Unit> Handle(ExcluirTimeCommand request, CancellationToken cancellationToken)
    {
        var time = await _timeRepository.GetByIdAsync(request.Id);
        if (time is null)
            throw new KeyNotFoundException($"O time com o ID: {request.Id} nao foi encontrado");
        
        await _timeRepository.DeleteAsync(time.Id);
        return Unit.Value;
    }
}