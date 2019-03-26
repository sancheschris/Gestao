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
    public class PlanoDeAulasController : ControllerBase
    {
        private readonly SeedAPIContext _context;

        public PlanoDeAulasController(SeedAPIContext context)
        {
            _context = context;
        }

        // GET: api/PlanoDeAulas
        [HttpGet]
        public IEnumerable<PlanoDeAula> GetPlanoDeAula()
        {
            return _context.PlanoDeAula;
        }

        // GET: api/PlanoDeAulas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlanoDeAula([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var planoDeAula = await _context.PlanoDeAula.FindAsync(id);

            if (planoDeAula == null)
            {
                return NotFound();
            }

            return Ok(planoDeAula);
        }

        // PUT: api/PlanoDeAulas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlanoDeAula([FromRoute] int id, [FromBody] PlanoDeAula planoDeAula)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != planoDeAula.PlanoId)
            {
                return BadRequest();
            }

            _context.Entry(planoDeAula).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlanoDeAulaExists(id))
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

        // POST: api/PlanoDeAulas
        [HttpPost]
        public async Task<IActionResult> PostPlanoDeAula([FromBody] PlanoDeAula planoDeAula)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PlanoDeAula.Add(planoDeAula);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlanoDeAula", new { id = planoDeAula.PlanoId }, planoDeAula);
        }

        // DELETE: api/PlanoDeAulas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlanoDeAula([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var planoDeAula = await _context.PlanoDeAula.FindAsync(id);
            if (planoDeAula == null)
            {
                return NotFound();
            }

            _context.PlanoDeAula.Remove(planoDeAula);
            await _context.SaveChangesAsync();

            return Ok(planoDeAula);
        }

        private bool PlanoDeAulaExists(int id)
        {
            return _context.PlanoDeAula.Any(e => e.PlanoId == id);
        }
    }
}