namespace Brasileirao.Application.DTOs;

public class RegistroDeGolsDTO
{
    public Guid JogadorId { get; set; }
    public int Minuto { get; set; }

    public RegistroDeGolsDTO(Guid jogadorId, int minuto)
    {
        JogadorId = jogadorId;
        Minuto = minuto;
    }
}