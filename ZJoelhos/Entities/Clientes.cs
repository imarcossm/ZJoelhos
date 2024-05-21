namespace ZJoelhos.Entities
{
    public class Clientes
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public Clientes()
        {
        }

        public Clientes(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
}
