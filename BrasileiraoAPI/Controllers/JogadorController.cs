using Brasileirao.Application.Commands.AdicionarJogador;
using Brasileirao.Application.Commands.AtualizarJogador;
using Brasileirao.Application.Commands.ExcluirJogador;
using Brasileirao.Application.Queries.BuscarJogadorPorId;
using Brasileirao.Application.Queries.BuscarTodosJogadores;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Brasileirao.API.Controllers;

[ApiController]
[Route("api/v1/jogador")]
public class JogadorController : ControllerBase
{
    private readonly IMediator _mediator;

    public JogadorController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(string? query)
    {
        var jogadorViewModel = new BuscarTodosJogadoresQuery(query);
        var jogadores = await _mediator.Send(jogadorViewModel);
        return Ok(jogadores);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var getJogadorId = new BuscarJogadorPorIdQuery(id);
        var jogador = await _mediator.Send(getJogadorId);
        if (jogador is null) return NotFound();
        return Ok(jogador);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] AdicionarJogadorCommand command)
    {
        var jogadorId = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById),  new { id = jogadorId }, command);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] AtualizarJogadorCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(ExcluirJogadorCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }
}