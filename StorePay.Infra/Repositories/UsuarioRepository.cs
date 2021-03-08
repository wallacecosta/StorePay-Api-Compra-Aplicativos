using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StorePay.Domain.Comum.Enums;
using StorePay.Domain.Entities;
using StorePay.Domain.Interfaces;
using StorePay.Infra.Context;
using StorePay.Infra.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorePay.Infra.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public UsuarioRepository(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<Resultado> Criar(Usuario usuario)
        {
            var user = new AppUser
            {
                UserName = usuario.NomeUsuario,
                Email = usuario.Email
            };

            var result = await _userManager.CreateAsync(user, usuario.Password);

            if (result.Errors.Any())
            {
                return Resultado.Falha;
            }
            
            var userIdentity = await _userManager.FindByEmailAsync(usuario.Email);

            usuario.IdentityId = userIdentity.Id;

            _context.Usuarios.Add(usuario);

            return (Resultado)await _context.SaveChangesAsync();
        }

        public async Task<Resultado> Alterar(Usuario usuario)
        {
            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                return (Resultado)await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Resultado.Falha;                
            }
        }        

        public async Task<Resultado> Excluir(Usuario usuario)
        {
            _context.Usuarios.Remove(usuario);

            try
            {
                return (Resultado)await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Resultado.Falha;
            }
        }

        public async Task<Usuario> ObterPorId(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            usuario.Password = string.Empty;

            return usuario;
        }

        public async Task<IEnumerable<Usuario>> ObterTodos()
        {
            var listaUsuarios = await _context.Usuarios.ToListAsync();

            foreach (var item in listaUsuarios)
            {
                item.Password = string.Empty;
            }

            return listaUsuarios;
        }
    }
}
