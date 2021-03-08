using StorePay.Domain.Comum.Enums;
using StorePay.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StorePay.Domain.Interfaces
{
    public interface IAplicativoRepository
    {
        Task<IEnumerable<Aplicativo>> ObterTodos();
        Task<Aplicativo> ObterPorId(int id);
        Task<Resultado> Criar(Aplicativo aplicativo);
        Task<Resultado> Alterar(Aplicativo aplicativo);
        Task<Resultado> Excluir(Aplicativo aplicativo);

    }
}
