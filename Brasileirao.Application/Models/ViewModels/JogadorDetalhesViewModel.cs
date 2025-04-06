using Brasileirao.Domain.Entities;

namespace Brasileirao.Application.Models.ViewModels;

public class JogadorDetalhesViewModel
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Posicao { get; set; }
    public string NumeroCamisa { get; set; }
    public string NomeTime { get; set; }
    public ICollection<TituloViewModel> Titulos { get; set; }
    public ICollection<RegistroDeGolsViewModel>  Gols { get; set; }

    public JogadorDetalhesViewModel(Guid id, string nome, string posicao, string numeroCamisa, string nomeTime, ICollection<TituloViewModel> titulos, ICollection<RegistroDeGolsViewModel> gols)
    {
        Id = id;
        Nome = nome;
        Posicao = posicao;
        NumeroCamisa = numeroCamisa;
        NomeTime = nomeTime;
        Titulos = titulos;
        Gols = gols;
    }
}