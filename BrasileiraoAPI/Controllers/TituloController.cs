using Brasileirao.Application.Commands.AdicionarTitulo;
using Brasileirao.Application.Commands.ExcluirTitulo;
using Brasileirao.Application.Models.ViewModels;
using Brasileirao.Application.Queries.BuscarTituloPorId;
using Brasileirao.Application.Queries.BuscarTodosTitulos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Brasileirao.API.Controllers;

[ApiController]
[Route("api/v1/titulo")]
public class TituloController : ControllerBase
{
    private readonly IMediator _mediator;

    public TituloController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(string? query)
    {
        var titulosViewModel = new BuscarTodosTitulosQuery(query);
        var titulos = await _mediator.Send(titulosViewModel);
        if (titulos is null) return NotFound();
        return Ok(titulos);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var tituloId = new BuscarTituloPorIdQuery(id);
        var titulo = await _mediator.Send(tituloId);
        if (titulo is null) return NotFound();
        return Ok(titulo);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] AdicionarTituloCommand command)
    {
        var titulodId = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = titulodId }, command);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(ExcluirTituloCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }
}