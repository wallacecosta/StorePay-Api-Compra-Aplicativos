using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StorePay.Models;

namespace StorePay.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AplicativosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AplicativosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Aplicativos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aplicativo>>> GetAplicativos()
        {
            return await _context.Aplicativos.ToListAsync();
        }

        // GET: api/Aplicativos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Aplicativo>> GetAplicativo(int id)
        {
            var aplicativo = await _context.Aplicativos.FindAsync(id);

            if (aplicativo == null)
            {
                return NotFound();
            }

            return aplicativo;
        }

        // PUT: api/Aplicativos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAplicativo(int id, Aplicativo aplicativo)
        {
            if (id != aplicativo.Id)
            {
                return BadRequest();
            }

            _context.Entry(aplicativo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AplicativoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Aplicativos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Aplicativo>> PostAplicativo(Aplicativo aplicativo)
        {
            _context.Aplicativos.Add(aplicativo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAplicativo", new { id = aplicativo.Id }, aplicativo);
        }

        // DELETE: api/Aplicativos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAplicativo(int id)
        {
            var aplicativo = await _context.Aplicativos.FindAsync(id);
            if (aplicativo == null)
            {
                return NotFound();
            }

            _context.Aplicativos.Remove(aplicativo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AplicativoExists(int id)
        {
            return _context.Aplicativos.Any(e => e.Id == id);
        }
    }
}
