namespace Brasileirao.Application.Models.ViewModels;

public class TituloJogadorViewModel
{
    public string NomeJogador { get; set; }
    public string NomeTitulo { get; set; }
    public int Quantidade { get; set; }

    public TituloJogadorViewModel(string nomeJogador, string nomeTitulo, int quantidade)
    {
        NomeJogador = nomeJogador;
        NomeTitulo = nomeTitulo;
        Quantidade = quantidade;
    }
}