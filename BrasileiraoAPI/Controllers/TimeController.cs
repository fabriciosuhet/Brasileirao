using Brasileirao.Application.Commands.AdicionarTime;
using Brasileirao.Application.Commands.AtualizarTime;
using Brasileirao.Application.Commands.ExcluirTime;
using Brasileirao.Application.Queries.BuscarTimePorId;
using Brasileirao.Application.Queries.BuscarTodosOsTimes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Brasileirao.API.Controllers;

[ApiController]
[Route("v1/api/time")]
public class TimeController : ControllerBase
{
    private readonly IMediator _mediator;

    public TimeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(string? query)
    {
        var timesViewModel = new BuscarTodosOsTimesQuery(query);
        var times = await _mediator.Send(timesViewModel);
        if (times is null) return NotFound();
        return Ok(times);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var timeId = new BuscarTimePorIdQuery(id);
        var time = await _mediator.Send(timeId);
        if (time is null) return NotFound();
        return Ok(time);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AdicionarTimeCommand command)
    {
        var timeId = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = timeId }, command);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] AtualizarTimeCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(ExcluirTimeCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }
}