namespace Brasileirao.Application.Models.ViewModels;

public class JogadorViewModel
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Posicao { get; set; }

    public JogadorViewModel(Guid id, string nome, string posicao)
    {
        Id = id;
        Nome = nome;
        Posicao = posicao;
    }
}