namespace Brasileirao.Domain.Entities
{
    public class JogadorTitulo : BaseEntity
    {
        public Guid JogadorId { get; private set; }
        public Jogador Jogador { get; private set; }

        public Guid TituloId { get; private set; }
        public Titulo Titulo { get; private set; }

        public int Quantidade { get; private set; }
        
        protected JogadorTitulo() { }

        public JogadorTitulo(Guid jogadorId, Guid tituloId, int quantidade)
        {
            JogadorId = jogadorId;
            TituloId = tituloId;
            Quantidade = quantidade;
        }

        public void AtualizarTituloJogador(Guid jogadorId, Guid tituloId, int quantidade)
        {
            JogadorId = jogadorId;
            TituloId = tituloId;
            Quantidade = quantidade;
        }
    }
}
