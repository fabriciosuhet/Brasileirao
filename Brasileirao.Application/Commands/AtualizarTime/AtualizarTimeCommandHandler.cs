using Brasileirao.Domain.Entities;
using Brasileirao.Domain.Repositories;
using MediatR;

namespace Brasileirao.Application.Commands.AtualizarTime;

public class AtualizarTimeCommandHandler : IRequestHandler<AtualizarTimeCommand, Unit>
{
    private readonly IRepository<Time> _timeRepository;

    public AtualizarTimeCommandHandler(IRepository<Time> timeRepository)
    {
        _timeRepository = timeRepository;
    }

    public async Task<Unit> Handle(AtualizarTimeCommand request, CancellationToken cancellationToken)
    {
        var time = await _timeRepository.GetByIdAsync(request.Id);
        if (time is null)
            throw new KeyNotFoundException($"Time com ID: {request.Id} nao encontrado");
        time.AlterarNome(request.Nome);
        
        await _timeRepository.UpdateAsync(time);
        return Unit.Value;
    }
}