using Brasileirao.Application.Commands.AdicionarCampeonatoTime;
using Brasileirao.Application.Commands.AtualizarCampeonatoTime;
using Brasileirao.Application.Commands.ExcluirCampeonatoTime;
using Brasileirao.Application.Queries.BuscarCampeonatoPorId;
using Brasileirao.Application.Queries.BuscarCampeonatoTimePorId;
using Brasileirao.Application.Queries.BuscarTodosCampeonatoTime;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Brasileirao.API.Controllers;

[ApiController]
[Route("api/v1/campeonato-time")]
public class CampeonatoTimeController : ControllerBase
{
    private readonly IMediator _mediator;

    public CampeonatoTimeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(string? query)
    {
        var getAllCampeonatoTime = new BuscarTodosCampeonatoTimeQuery(query);
        var campeonatosTimes = await _mediator.Send(getAllCampeonatoTime);
        if (campeonatosTimes is null) return NotFound();
        return Ok(campeonatosTimes);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var getCampeonatoTimeById = new BuscarCampeonatoTimePorIdQuery(id);
        var campeonatoTime = await _mediator.Send(getCampeonatoTimeById);
        if (getCampeonatoTimeById is null) return NotFound();
        return Ok(campeonatoTime);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] AdicionarCampeonatoTimeCommand command)
    {
        var campeonatoTime = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = campeonatoTime }, command);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] AtualizarCampeonatoTimeCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(ExcluirCampeonatoTimeCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

}