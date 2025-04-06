namespace Brasileirao.Application.Models.ViewModels;

public class EventoPartidaViewModel
{
    public string TipoEvento { get; set; }
    public string NomeJogador { get; set; }
    public string NomeTime { get; set; }
    public int Minuto { get; set; }

    public EventoPartidaViewModel(string tipoEvento, string nomeJogador, string nomeTime, int minuto)
    {
        TipoEvento = tipoEvento;
        NomeJogador = nomeJogador;
        NomeTime = nomeTime;
        Minuto = minuto;
    }
}