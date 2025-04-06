using Brasileirao.Application.DTOs;
using Brasileirao.Domain.Entities;
using MediatR;

namespace Brasileirao.Application.Commands.AdicionarPartida;

public class AdicionarPartidaCommand : IRequest<Guid>
{
    public DateTime DataDaPartida { get; set; }
    public Guid CampeonatoId { get; set; }
    public Guid TimeMandanteId { get; set; }
    public Guid TimeVisitanteId { get; set; }
    
    public AdicionarPartidaCommand(DateTime dataDaPartida, Guid campeonatoId, Guid timeMandanteId, Guid timeVisitanteId)
    {
        DataDaPartida = dataDaPartida;
        CampeonatoId = campeonatoId;
        TimeMandanteId = timeMandanteId;
        TimeVisitanteId = timeVisitanteId;
    }
}