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
    public class TemperaturaController : ControllerBase
    {
        private readonly EstufaContext _context;

        public TemperaturaController(EstufaContext context)
        {
            _context = context;
        }

        // GET: api/Temperatura
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Temperatura>>> GetTemperatura()
        {
            return await _context.Temperatura.ToListAsync();
        }

        

        // POST: api/Temperatura
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Temperatura>> PostTemperatura(Temperatura temperatura)
        {
            _context.Temperatura.Add(temperatura);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTemperatura", new { id = temperatura.Id }, temperatura);
        }

        // DELETE: api/Temperatura/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTemperatura(int id)
        {
            var temperatura = await _context.Temperatura.FindAsync(id);
            if (temperatura == null)
            {
                return NotFound();
            }

            _context.Temperatura.Remove(temperatura);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TemperaturaExists(int id)
        {
            return _context.Temperatura.Any(e => e.Id == id);
        }
    }
}
