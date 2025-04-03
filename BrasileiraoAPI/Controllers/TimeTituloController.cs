using Brasileirao.Application.Commands.AdicionarTimeTitulo;
using Brasileirao.Application.Commands.AtualizarTimeTitulo;
using Brasileirao.Application.Commands.ExcluirTimeTitulo;
using Brasileirao.Application.Queries.BuscarTituloTimePorId;
using Brasileirao.Application.Queries.BuscarTodosTitulosTime;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Brasileirao.API.Controllers;

[ApiController]
[Route("api/v1/time-titulo")]
public class TimeTituloController : ControllerBase
{
    private readonly IMediator _mediator;

    public TimeTituloController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(string? query)
    {
        var timeTituloViewModel = new BuscarTodosTitulosTimeQuery(query);
        var timesTitulos = await _mediator.Send(timeTituloViewModel);
        if (timesTitulos is null) return NotFound();
        return Ok(timesTitulos);
    }

    [HttpGet("{timeId:guid}/{tituloId:guid}")]
    public async Task<IActionResult> GetById(Guid timeId, Guid tituloId)
    {
        var getTimeTituloPorId = new BuscarTituloTimePorIdQuery(timeId, tituloId);
        var timeTitulo = await _mediator.Send(getTimeTituloPorId);
        if (timeTitulo is null) return NotFound();
        return Ok(timeTitulo);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] AdicionarTimeTiuloCommand command)
    {
        var timeTitulo = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { timeId = timeTitulo.Item1, tituloId = timeTitulo.Item2 }, command);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] AtualizarTimeTituloCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(ExcluirTimeTituloCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }
    
}