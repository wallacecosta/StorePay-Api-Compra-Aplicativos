﻿namespace StorePay.Api.ViewModels
{
    public class AplicativoVM
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Produtora { get; set; }
        public string Tamanho { get; set; }
        public decimal Preco { get; set; }

        public AplicativoVM()
        {

        }
    }
}
