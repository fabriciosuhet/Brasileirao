namespace Brasileirao.Application.Models.ViewModels;

public class TimeViewModel
{
    public Guid Id { get; set; }
    public string Nome { get; set; }

    public TimeViewModel(Guid id, string nome)
    {
        Id = id;
        Nome = nome;
    }
}