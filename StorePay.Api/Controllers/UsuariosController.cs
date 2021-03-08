using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using StorePay.Api.ViewModels;
using StorePay.Domain.Comum.Enums;
using StorePay.Domain.Entities;
using StorePay.Domain.Interfaces;
using StorePay.Infra.Models;
using StorePay.Services;

namespace StorePay.Api.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private IUsuarioRepository _usuarioRepository;

        public UsuariosController(IUsuarioRepository usuarioRepository, IMapper mapper, IConfiguration configuration)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
            _configuration = configuration;
        }


        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioVM>>> GetUsuarios()
        {
            var usuarios = await _usuarioRepository.ObterTodos();
            var listaUsuarios = new List<UsuarioVM>();

            foreach (var item in usuarios)
            {
                listaUsuarios.Add(_mapper.Map<UsuarioVM>(item));
            }

            return listaUsuarios;

        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioVM>> GetUsuario(int id)
        {
            var usuario = await _usuarioRepository.ObterPorId(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return _mapper.Map<UsuarioVM>(usuario);
        }

        // PUT: api/Usuarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, UsuarioVM usuarioVM)
        {
            if (id != usuarioVM.Id)
            {
                return BadRequest();
            }

            var result = await _usuarioRepository.Alterar(_mapper.Map<Usuario>(usuarioVM));

            if(result.Equals(Resultado.Falha))
            {
                ModelState.AddModelError("Error", "Ocorreu uma falha e não foi possível alterar o usuário.");
                return BadRequest(ModelState);
            }

            return NoContent();
        }

        // POST: api/Usuarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserToken>> PostUsuario(UsuarioVM usuarioVM)
        {
            var result = await _usuarioRepository.Criar(_mapper.Map<Usuario>(usuarioVM));

            if (result.Equals(Resultado.Falha))
            {
                ModelState.AddModelError("Error", "Não foi possível criar o usuário.");
                return BadRequest(ModelState);
            }

            return new TokenService(_configuration).BuildToken(usuarioVM.Email);
            
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = await _usuarioRepository.ObterPorId(id);
            if (usuario == null)
            {
                return NotFound();
            }

            var result = await _usuarioRepository.Excluir(usuario);

            if (result.Equals(Resultado.Falha))
            {
                ModelState.AddModelError("Error", "Ocorreu uma falha e não foi possível deletar o usuário.");
                return BadRequest(ModelState);
            }

            return NoContent();
        }
    }
}
