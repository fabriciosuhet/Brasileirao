namespace Brasileirao.Application.Models.ViewModels;

public class TituloViewModel
{
    public Guid Id { get; set; }
    public string Nome { get; set; }

    public TituloViewModel(Guid id, string nome)
    {
        Id = id;
        Nome = nome;
    }
}