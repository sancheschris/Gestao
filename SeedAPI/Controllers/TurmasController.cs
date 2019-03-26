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
    public class TurmasController : ControllerBase
    {
        private readonly SeedAPIContext _context;

        public TurmasController(SeedAPIContext context)
        {
            _context = context;
        }

        // GET: api/Turmas
        [HttpGet]
        public IEnumerable<Turma> GetTurma()
        {
            return _context.Turma;
        }

        // GET: api/Turmas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTurma([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var turma = await _context.Turma.FindAsync(id);

            if (turma == null)
            {
                return NotFound();
            }

            return Ok(turma);
        }

        // PUT: api/Turmas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTurma([FromRoute] int id, [FromBody] Turma turma)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != turma.TurmaId)
            {
                return BadRequest();
            }

            _context.Entry(turma).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TurmaExists(id))
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

        // POST: api/Turmas
        [HttpPost]
        public async Task<IActionResult> PostTurma([FromBody] Turma turma)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Turma.Add(turma);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTurma", new { id = turma.TurmaId }, turma);
        }

        // DELETE: api/Turmas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTurma([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var turma = await _context.Turma.FindAsync(id);
            if (turma == null)
            {
                return NotFound();
            }

            _context.Turma.Remove(turma);
            await _context.SaveChangesAsync();

            return Ok(turma);
        }

        private bool TurmaExists(int id)
        {
            return _context.Turma.Any(e => e.TurmaId == id);
        }
    }
}