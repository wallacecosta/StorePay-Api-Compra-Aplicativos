using StorePay.Domain.Comum.Enums;
using System;

namespace StorePay.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string NomeUsuario { get; set; }
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Endereco { get; set; }
        public TipoSexo Sexo { get; set; }
        public string IdentityId {get; set;}

        public Usuario()
        {

        }

        public bool Valido()
        {
            throw new NotImplementedException();
        }
    }
}
