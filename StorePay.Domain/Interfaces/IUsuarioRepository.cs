using StorePay.Domain.Comum.Enums;
using StorePay.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StorePay.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> ObterTodos();
        Task<Usuario> ObterPorId(int id);
        Task<Resultado> Criar(Usuario usuario);
        Task<Resultado> Alterar(Usuario usuario);
        Task<Resultado> Excluir(Usuario usuario);


    }
}
