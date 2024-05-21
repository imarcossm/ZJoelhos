using ZJoelhos.Entities;

namespace ZJoelhos
{
    public class Pedido
    {
        public int Id { get; set; }
        public Clientes Cliente { get; set; }
        public Joelhos Joelho { get; set; }

        public Pedido(int id, Clientes cliente, Joelhos joelho)
        {
            Id = id;
            Cliente = cliente;
            Joelho = joelho;
        }
    }
}
