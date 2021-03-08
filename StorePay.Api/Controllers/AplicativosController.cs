using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StorePay.Api.ViewModels;
using StorePay.Domain.Comum.Enums;
using StorePay.Domain.Entities;
using StorePay.Domain.Interfaces;

namespace StorePay.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AplicativosController : ControllerBase
    {
        private IAplicativoRepository _aplicativoRepository;
        private readonly IMapper _mapper;

        public AplicativosController(IAplicativoRepository aplicativoRepository, IMapper mapper)
        {
            _aplicativoRepository = aplicativoRepository;
            _mapper = mapper;
        }

        // GET: api/Aplicativos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AplicativoVM>>> GetAplicativos()
        {
            var aplicativos = await _aplicativoRepository.ObterTodos();
            var listaAplicativos = new List<AplicativoVM>();

            foreach (var item in aplicativos)
            {
                listaAplicativos.Add(_mapper.Map<AplicativoVM>(item));
            }

            return listaAplicativos;
        }

        // GET: api/Aplicativos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AplicativoVM>> GetAplicativo(int id)
        {
            var aplicativo = await _aplicativoRepository.ObterPorId(id);

            if (aplicativo == null)
            {
                return NotFound();
            }

            return _mapper.Map<AplicativoVM>(aplicativo);
        }

        [Authorize]
        // PUT: api/Aplicativos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAplicativo(int id, AplicativoVM aplicativoVM)
        {
            if (id != aplicativoVM.Id)
            {
                return BadRequest();
            }

            var result = await _aplicativoRepository.Alterar(_mapper.Map<Aplicativo>(aplicativoVM));

            if (result.Equals(Resultado.Falha))
            {
                ModelState.AddModelError("Error", "Ocorreu uma falha e não foi possível alterar o aplicativo.");
                return BadRequest(ModelState);
            }

            return NoContent();
        }

        [Authorize]
        // POST: api/Aplicativos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AplicativoVM>> PostAplicativo(AplicativoVM aplicativoVM)
        {
            var aplicativo = _mapper.Map<Aplicativo>(aplicativoVM);
            var result = await _aplicativoRepository.Criar(_mapper.Map<Aplicativo>(aplicativoVM));

            if (result.Equals(Resultado.Falha))
            {
                ModelState.AddModelError("Error", "Não foi possível criar o aplicativo.");
                return BadRequest(ModelState);
            }

            return CreatedAtAction("GetAplicativo", new { id = aplicativo.Id }, aplicativo);
        }

        [Authorize]
        // DELETE: api/Aplicativos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAplicativo(int id)
        {
            var aplicativo = await _aplicativoRepository.ObterPorId(id);
            if (aplicativo == null)
            {
                return NotFound();
            }

            var result = await _aplicativoRepository.Excluir(aplicativo);

            if (result.Equals(Resultado.Falha))
            {
                ModelState.AddModelError("Error", "Ocorreu uma falha e não foi possível deletar o aplicativo.");
                return BadRequest(ModelState);
            }

            return NoContent();
        }

    }
}
