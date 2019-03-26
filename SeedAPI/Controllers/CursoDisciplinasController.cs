using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeedAPI.Model;
using SeedAPI.Models;

namespace SeedAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoDisciplinasController : ControllerBase
    {
        private readonly SeedAPIContext _context;

        public CursoDisciplinasController(SeedAPIContext context)
        {
            _context = context;
        }

        // GET: api/CursoDisciplinas
        [HttpGet]
        public IEnumerable<CursoDisciplina> GetCursoDisciplina()
        {
            return _context.CursoDisciplina;
        }

        // GET: api/CursoDisciplinas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCursoDisciplina([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cursoDisciplina = await _context.CursoDisciplina.FindAsync(id);

            if (cursoDisciplina == null)
            {
                return NotFound();
            }

            return Ok(cursoDisciplina);
        }

        // PUT: api/CursoDisciplinas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCursoDisciplina([FromRoute] int id, [FromBody] CursoDisciplina cursoDisciplina)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cursoDisciplina.CursoDisciplinaId)
            {
                return BadRequest();
            }

            _context.Entry(cursoDisciplina).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CursoDisciplinaExists(id))
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

        // POST: api/CursoDisciplinas
        [HttpPost]
        public async Task<IActionResult> PostCursoDisciplina([FromBody] CursoDisciplina cursoDisciplina)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.CursoDisciplina.Add(cursoDisciplina);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCursoDisciplina", new { id = cursoDisciplina.CursoDisciplinaId }, cursoDisciplina);
        }

        // DELETE: api/CursoDisciplinas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCursoDisciplina([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cursoDisciplina = await _context.CursoDisciplina.FindAsync(id);
            if (cursoDisciplina == null)
            {
                return NotFound();
            }

            _context.CursoDisciplina.Remove(cursoDisciplina);
            await _context.SaveChangesAsync();

            return Ok(cursoDisciplina);
        }

        private bool CursoDisciplinaExists(int id)
        {
            return _context.CursoDisciplina.Any(e => e.CursoDisciplinaId == id);
        }
    }
}