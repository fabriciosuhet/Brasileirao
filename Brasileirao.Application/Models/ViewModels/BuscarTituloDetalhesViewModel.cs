namespace Brasileirao.Application.Models.ViewModels;

public class BuscarTituloDetalhesViewModel
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public DateTime DataTitulo { get; set; }
    public ICollection<TituloTimeViewModel> Times { get; set; }

    public BuscarTituloDetalhesViewModel(Guid id, string nome, DateTime dataTitulo, ICollection<TituloTimeViewModel> times)
    {
        Id = id;
        Nome = nome;
        DataTitulo = dataTitulo;
       Times = times;
    }
}