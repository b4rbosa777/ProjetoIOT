using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Estufa.Data;
using Estufa.Models;

namespace Estufa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LampadaController : ControllerBase
    {
        private readonly EstufaContext _context;

        public LampadaController(EstufaContext context)
        {
            _context = context;
        }

        // GET: api/Lampada
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lampada>>> GetLampada()
        {
            return await _context.Lampada.ToListAsync();
        }

        // GET: api/Lampada/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lampada>> GetLampada(int id)
        {
            var lampada = await _context.Lampada.FindAsync(id);

            if (lampada == null)
            {
                return NotFound();
            }

            return lampada;
        }

        // PUT: api/Lampada/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLampada(int id, Lampada lampada)
        {
            if (id != lampada.Id)
            {
                return BadRequest();
            }

            _context.Entry(lampada).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LampadaExists(id))
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

        // POST: api/Lampada
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Lampada>> PostLampada(Lampada lampada)
        {
            _context.Lampada.Add(lampada);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLampada", new { id = lampada.Id }, lampada);
        }

        // DELETE: api/Lampada/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLampada(int id)
        {
            var lampada = await _context.Lampada.FindAsync(id);
            if (lampada == null)
            {
                return NotFound();
            }

            _context.Lampada.Remove(lampada);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LampadaExists(int id)
        {
            return _context.Lampada.Any(e => e.Id == id);
        }
    }
}
