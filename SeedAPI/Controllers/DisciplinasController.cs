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
    public class DisciplinasController : ControllerBase
    {
        private readonly SeedAPIContext _context;

        public DisciplinasController(SeedAPIContext context)
        {
            _context = context;
        }

        // GET: api/Disciplinas
        [HttpGet]
        public IEnumerable<Disciplina> GetDisciplina()
        {
            return _context.Disciplina;
        }

        // GET: api/Disciplinas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDisciplina([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var disciplina = await _context.Disciplina.FindAsync(id);

            if (disciplina == null)
            {
                return NotFound();
            }

            return Ok(disciplina);
        }

        // PUT: api/Disciplinas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDisciplina([FromRoute] int id, [FromBody] Disciplina disciplina)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != disciplina.DisciplinaId)
            {
                return BadRequest();
            }

            _context.Entry(disciplina).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DisciplinaExists(id))
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

        // POST: api/Disciplinas
        [HttpPost]
        public async Task<IActionResult> PostDisciplina([FromBody] Disciplina disciplina)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Disciplina.Add(disciplina);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDisciplina", new { id = disciplina.DisciplinaId }, disciplina);
        }

        // DELETE: api/Disciplinas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDisciplina([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var disciplina = await _context.Disciplina.FindAsync(id);
            if (disciplina == null)
            {
                return NotFound();
            }

            _context.Disciplina.Remove(disciplina);
            await _context.SaveChangesAsync();

            return Ok(disciplina);
        }

        private bool DisciplinaExists(int id)
        {
            return _context.Disciplina.Any(e => e.DisciplinaId == id);
        }
    }
}