namespace Brasileirao.Domain.Entities
{
    public class Titulo : BaseEntity
    {
        public string Nome { get; private set; }
        public DateTime DataTituto { get; private set; }
        
        public ICollection<TimeTitulo> Times { get; private set; } = new  List<TimeTitulo>();
        public ICollection<JogadorTitulo> Jogadores { get; private set; } = new   List<JogadorTitulo>();
        
        protected Titulo() { }
        
        public Titulo(string nome, DateTime dataTitulo)
        {
            Nome = nome;
            DataTituto = dataTitulo;
        }
    }
}
