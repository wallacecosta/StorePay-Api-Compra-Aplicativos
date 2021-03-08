using Microsoft.EntityFrameworkCore;
using StorePay.Domain.Comum.Enums;
using StorePay.Domain.Entities;
using StorePay.Domain.Interfaces;
using StorePay.Infra.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StorePay.Infra.Repositories
{
    public class AplicativoRepository : IAplicativoRepository
    {
        private AppDbContext _context;

        public AplicativoRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public async Task<Resultado> Alterar(Aplicativo aplicativo)
        {
            _context.Entry(aplicativo).State = EntityState.Modified;

            try
            {
                return (Resultado)await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Resultado.Falha;
            }
        }

        public async Task<Resultado> Criar(Aplicativo aplicativo)
        {
            _context.Aplicativos.Add(aplicativo);

            return (Resultado)await _context.SaveChangesAsync();
        }

        public async Task<Resultado> Excluir(Aplicativo aplicativo)
        {
            _context.Aplicativos.Remove(aplicativo);

            try
            {
                return (Resultado)await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Resultado.Falha;
            }
        }

        public async Task<Aplicativo> ObterPorId(int id)
        {
            return await _context.Aplicativos.FindAsync(id);
        }

        public async Task<IEnumerable<Aplicativo>> ObterTodos()
        {
            return await _context.Aplicativos.ToListAsync();
        }
    }
}
