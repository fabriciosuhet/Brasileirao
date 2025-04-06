using Brasileirao.Application.Commands.AdicionarEvento;
using Brasileirao.Application.Commands.AdicionarGol;
using Brasileirao.Application.Commands.AdicionarPartida;
using Brasileirao.Application.Models.ViewModels;
using Brasileirao.Application.Queries.BuscarPartidaPorId;
using Brasileirao.Application.Queries.BuscarTodasPartidas;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Brasileirao.API.Controllers;

[ApiController]
[Route("api/v1/partida")]
public class PartidaController : ControllerBase
{
    private readonly IMediator _mediator;

    public PartidaController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAll(string? query)
    {
        var partidasViewModel = new BuscarTodasPartidasQuery(query);
        var partidas =  await _mediator.Send(partidasViewModel);
        return Ok(partidas);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var getPartidaId =  new BuscarPartidaPorIdQuery(id);
        var partida = await _mediator.Send(getPartidaId);
        if (partida is null) return NotFound();
        return Ok(partida);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] AdicionarPartidaCommand command)
    {
        var partidaId = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById),  new { id = partidaId }, command);
    }

    [HttpPost("{id:guid}/gols")]
    public async Task<IActionResult> PostGols([FromBody] AdicionarGolCommand command)
    {
        var golId = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = golId }, command);
    }
    
    [HttpPost("{id:guid}/eventos")]
    public async Task<IActionResult> PostEventos([FromBody] AdicionarEventoCommand command)
    {
        var eventoId = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = eventoId }, command);
    }
    
}