namespace Brasileirao.Application.DTOs;

public class EventoPartidaDTO
{
    public Guid JogadorId { get; set; }
    public string TipoEvento { get; set; }
    public int Minuto { get; set; }

    public EventoPartidaDTO(Guid jogadorId, string tipoEvento, int minuto)
    {
        JogadorId = jogadorId;
        TipoEvento = tipoEvento;
        Minuto = minuto;
    }
}