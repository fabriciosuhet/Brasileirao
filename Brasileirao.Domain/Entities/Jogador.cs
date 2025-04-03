namespace Brasileirao.Domain.Entities
{
    public class Jogador : BaseEntity
    {
        public string Nome { get; private set; }
        public string Posicao { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string NumeroCamisa { get; private set; }

        public Time Time { get; private set; }
        public Guid TimeId { get; private set; }

        public ICollection<JogadorTitulo> Titulos { get; private set; } = new List<JogadorTitulo>();
        
        protected Jogador() { }

        public Jogador(string nome, string posicao, DateTime dataNascimento, string numeroCamisa, Guid timeId)
        {
            Nome = nome;
            Posicao = posicao;
            DataNascimento = dataNascimento;
            NumeroCamisa = numeroCamisa;
            TimeId = timeId;
        }

        public void AlterarDadosJogador(string posicao, string numeroCamisa)
        {
            Posicao = posicao;
            NumeroCamisa = numeroCamisa;
        }
    }
}
