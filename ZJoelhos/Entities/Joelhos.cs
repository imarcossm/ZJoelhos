namespace ZJoelhos.Entities
{
    public class Joelhos
    {
        public int Id { get; set; }
        public string Sabor { get; set; }
        public string Observacao { get; set; }  // Nova propriedade

        public Joelhos(int id, string sabor, string observacao)
        {
            Id = id;
            Sabor = sabor;
            Observacao = observacao;  // Novo parâmetro
        }
    }
}
