namespace Brasileirao.Domain.Entities
{
    public class TimeTitulo : BaseEntity
    {
        public Guid TimeId { get; set; }
        public Time Time { get; private set; }


        public Titulo Titulo { get; private set; }
        public Guid TituloId { get; set; }

        public int Quantidade { get; private set; }
        
        protected TimeTitulo() { }

        public TimeTitulo(Guid timeId, Guid tituloId, int quantidade)
        {
            TimeId = timeId;
            TituloId = tituloId;
            Quantidade = quantidade;
        }
        
        public void AtualizarQuantidade(int quantidade) => Quantidade = quantidade;
    }
}
