using Brasileirao.Application.Commands.AdicionarCampeonato;
using Brasileirao.Application.Commands.AtualizarCampeonato;
using Brasileirao.Application.Commands.ExcluirCampeonato;
using Brasileirao.Application.Queries.BuscarCampeonatoPorId;
using Brasileirao.Application.Queries.BuscarTodosCampeonatos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Brasileirao.API.Controllers;

[ApiController]
[Route("api/v1/campeonato")]
public class CampeonatoController : ControllerBase
{
    private readonly IMediator _mediator;

    public CampeonatoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(string? query)
    {
        var getAllCampeonatos = new BuscarTodosCampeonatosQuery(query);
        var campeonatos =  await _mediator.Send(getAllCampeonatos);
        if (campeonatos is null) return NotFound();
        return Ok(campeonatos);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var getCampeonatoById = new BuscarCampeonatoPorIdQuery(id);
        var campeonato = await _mediator.Send(getCampeonatoById);
        if (campeonato is null) return NotFound();
        return Ok(campeonato);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] AdicionarCampeonatoCommand command)
    {
        var campeonatoId = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById),  new { id = campeonatoId }, command);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] AtualizarCampeonatoCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(ExcluirCampeonatoCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }
    
}