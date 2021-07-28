using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GamingPortal.Data;
using GamingPortal.Models;

namespace GamingPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Gmes1Controller : ControllerBase
    {
        private readonly GamingPortalContext _context;

        public Gmes1Controller(GamingPortalContext context)
        {
            _context = context;
        }

        // GET: api/Gmes1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gme>>> GetGme()
        {
            return await _context.Gme.ToListAsync();
        }

        // GET: api/Gmes1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Gme>> GetGme(int id)
        {
            var gme = await _context.Gme.FindAsync(id);

            if (gme == null)
            {
                return NotFound();
            }

            return gme;
        }

        // PUT: api/Gmes1/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGme(int id, Gme gme)
        {
            if (id != gme.id)
            {
                return BadRequest();
            }

            _context.Entry(gme).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GmeExists(id))
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

        // POST: api/Gmes1
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Gme>> PostGme(Gme gme)
        {
            _context.Gme.Add(gme);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGme", new { id = gme.id }, gme);
        }

        // DELETE: api/Gmes1/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Gme>> DeleteGme(int id)
        {
            var gme = await _context.Gme.FindAsync(id);
            if (gme == null)
            {
                return NotFound();
            }

            _context.Gme.Remove(gme);
            await _context.SaveChangesAsync();

            return gme;
        }

        private bool GmeExists(int id)
        {
            return _context.Gme.Any(e => e.id == id);
        }
    }
}
