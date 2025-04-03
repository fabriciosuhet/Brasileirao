namespace Brasileirao.Application.Models.ViewModels;

public class CampeonatoViewModel
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public int Ano { get; set; }

    public CampeonatoViewModel(Guid id, string nome, int ano)
    {
        Id = id;
        Nome = nome;
        Ano = ano;
    }
}