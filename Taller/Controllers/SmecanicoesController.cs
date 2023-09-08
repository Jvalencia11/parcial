using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Taller.Models;

namespace Taller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmecanicoesController : ControllerBase
    {
        private readonly TallerMecanicoContext _context;

        public SmecanicoesController(TallerMecanicoContext context)
        {
            _context = context;
        }

        // GET: api/Smecanicoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Smecanico>>> GetSmecanicos()
        {
          if (_context.Smecanicos == null)
          {
              return NotFound();
          }
            return await _context.Smecanicos.ToListAsync();
        }

        // GET: api/Smecanicoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Smecanico>> GetSmecanico(int id)
        {
          if (_context.Smecanicos == null)
          {
              return NotFound();
          }
            var smecanico = await _context.Smecanicos.FindAsync(id);

            if (smecanico == null)
            {
                return NotFound();
            }

            return smecanico;
        }

        // PUT: api/Smecanicoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSmecanico(int id, Smecanico smecanico)
        {
            if (id != smecanico.IdMecanico)
            {
                return BadRequest();
            }

            _context.Entry(smecanico).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SmecanicoExists(id))
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

        // POST: api/Smecanicoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Smecanico>> PostSmecanico(Smecanico smecanico)
        {
          if (_context.Smecanicos == null)
          {
              return Problem("Entity set 'TallerMecanicoContext.Smecanicos'  is null.");
          }
            _context.Smecanicos.Add(smecanico);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSmecanico", new { id = smecanico.IdMecanico }, smecanico);
        }

        // DELETE: api/Smecanicoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSmecanico(int id)
        {
            if (_context.Smecanicos == null)
            {
                return NotFound();
            }
            var smecanico = await _context.Smecanicos.FindAsync(id);
            if (smecanico == null)
            {
                return NotFound();
            }

            _context.Smecanicos.Remove(smecanico);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SmecanicoExists(int id)
        {
            return (_context.Smecanicos?.Any(e => e.IdMecanico == id)).GetValueOrDefault();
        }
    }
}
