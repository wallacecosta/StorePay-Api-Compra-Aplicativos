namespace StorePay.Infra.Models
{
    public class Aplicativo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Produtora { get; set; }
        public string Tamanho { get; set; }
        public decimal Preco { get; set; }
    }
}
