using Brasileirao.Application.Commands.AdicionarJogadorTitulo;
using Brasileirao.Application.Commands.AtualizarJogadorTitulo;
using Brasileirao.Application.Commands.ExcluirJogadorTitulo;
using Brasileirao.Application.Queries.BuscarTituloJogador;
using Brasileirao.Application.Queries.BuscarTodosTitulosJogador;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Brasileirao.API.Controllers;

[ApiController]
[Route("api/v1/jogador-titulo")]
public class JogadorTituloController : ControllerBase
{
    private readonly IMediator _mediator;

    public JogadorTituloController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(string? query)
    {
        var jogadorTituloViewModel = new BuscarTodosTitulosJogadorQuery(query);
        var jogadorTitlos = await _mediator.Send(jogadorTituloViewModel);
        if (jogadorTitlos is null)
        {
            return NotFound();
        }
        return Ok(jogadorTitlos);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var getJogadorTituloId = new BuscarTituloJogadorQuery(id);
        var jogador= await _mediator.Send(getJogadorTituloId);
        if (jogador is null) return NotFound();
        return Ok(jogador);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] AdicionarJogadorTituloCommand command)
    {
        var jogadorTitulo = await _mediator.Send(command);
        CreatedAtAction(nameof(GetById), new { id = jogadorTitulo }, jogadorTitulo);
        return NoContent();
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] AtualizarJogadorTituloCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(ExcluirJogadorTituloCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

}