namespace Brasileirao.Application.Models.ViewModels;

public class TituloTimeViewModel
{
    public Guid TimeId { get; set; }
    public Guid TituloId { get; set; }
    public string NomeTime { get; set; }
    public string NomeTitulo { get; set; }
    public int Quantidade { get; set; }

    public TituloTimeViewModel(Guid timeId, Guid tituloId, string nomeTime, string nomeTitulo, int quantidade)
    {
        TimeId = timeId;
        TituloId = tituloId;
        NomeTime = nomeTime;
        NomeTitulo = nomeTitulo;
        Quantidade = quantidade;
    }
}