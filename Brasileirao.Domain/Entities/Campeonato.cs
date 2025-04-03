namespace Brasileirao.Domain.Entities
{
    public class Campeonato : BaseEntity
    {
        public string Nome { get; private set; }
        public int Ano { get; private set; }
        public ICollection<CampeonatoTime> CampeonatoTimes { get; private set; } = new List<CampeonatoTime>();
        public ICollection<Partida> Partidas { get; private set; } =  new List<Partida>();
        
        protected Campeonato() { }

        public Campeonato(string nome, int ano)
        {
            Nome = nome;
            Ano = ano;
        }
        
        public void AlterarNomeCampeonato(string nome) => Nome = nome;
    }
}
