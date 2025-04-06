namespace Brasileirao.Application.Models.ViewModels;

public class RegistroDeGolsViewModel
{
    public string NomeJogador { get; set; }
    public string NomeTime { get; set; }
    public int MinutoGol { get; set; }

    public RegistroDeGolsViewModel(string nomeJogador, string nomeTime, int minutoGol)
    {
        NomeJogador = nomeJogador;
        NomeTime = nomeTime;
        MinutoGol = minutoGol;
    }
}