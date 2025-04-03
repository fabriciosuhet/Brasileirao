namespace Brasileirao.Application.Models.ViewModels;

public class CampeonatoDetalhesViewModel
{
    public Guid Id { get; set; }
    public string NomeCampeonato { get; set; }
    public IEnumerable<TimeViewModel> Times { get;  set; }

    public CampeonatoDetalhesViewModel(Guid id, string nomeCampeonato, IEnumerable<TimeViewModel> times)
    {
        Id = id;
        NomeCampeonato = nomeCampeonato;
        Times = times;
    }
}