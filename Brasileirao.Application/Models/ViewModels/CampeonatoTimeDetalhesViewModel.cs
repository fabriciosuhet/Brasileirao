namespace Brasileirao.Application.Models.ViewModels;

public class CampeonatoTimeDetalhesViewModel
{
    public Guid Id { get; set; }
    public Guid CampeonatoId { get; set; }
    public string NomeCampeonato { get; set; }
    public Guid TimeId { get; set; }
    public string NomeTime { get; set; }

    public CampeonatoTimeDetalhesViewModel(Guid id, Guid campeonatoId, string nomeCampeonato, Guid timeId, string nomeTime)
    {
        Id = id;
        CampeonatoId = campeonatoId;
        NomeCampeonato = nomeCampeonato;
        TimeId = timeId;
        NomeTime = nomeTime;
    }
}