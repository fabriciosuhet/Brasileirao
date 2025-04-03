namespace Brasileirao.Domain.Entities
{
    public class Time : BaseEntity
    {
        public string Nome { get; private set; }
        public string Estado { get; private set; }
        public ICollection<Jogador> Jogadores { get; private set; } = new List<Jogador>();
        public ICollection<TimeTitulo> Titulos { get; private set; } = new List<TimeTitulo>();
        public ICollection<CampeonatoTime> CampeonatoTimes { get; private set; } = new List<CampeonatoTime>();
        
        protected Time() { }

        public Time(string nome, string estado)
        {
            Nome = nome;
            Estado = estado;
        }

        public void AlterarNome(string nome) => Nome = nome;
    }
}
