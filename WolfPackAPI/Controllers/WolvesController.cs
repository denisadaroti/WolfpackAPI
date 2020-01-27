using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WolfPackAPI.Data;
using WolfPackAPI.Models;

namespace WolfPackAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WolvesController : ControllerBase
    {
        private readonly WolfPackAPIContext _context;

        public WolvesController(WolfPackAPIContext context)
        {
            _context = context;
        }

        // GET: api/Wolves
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Wolf>>> GetWolf()
        {
            return await _context.Wolf.Include(wo => wo.Location).ToListAsync();
        }

        // GET: api/Wolves/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Wolf>> GetWolf(int id)
        {
            if (WolfExists(id))
            {
                return _context.Wolf.Include(w => w.Location).SingleOrDefault(w => w.Id == id);

            }
            else
            {
                return NotFound();
            }
        }

        // PUT: api/Wolves/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWolf(int id, Wolf wolf)
        {
            if (id != wolf.Id)
            {
                return BadRequest();
            }

            _context.Entry(wolf).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WolfExists(id))
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
        
        // POST: api/Wolves
        [HttpPost]
        public async Task<ActionResult<Wolf>> PostWolf(Wolf wolf)
        {
            _context.Wolf.Add(wolf);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWolf", new { id = wolf.Id }, wolf);
        }

        // DELETE: api/Wolves/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Wolf>> DeleteWolf(int id)
        {
            var wolf = await _context.Wolf.FindAsync(id);
            if (wolf == null)
            {
                return NotFound();
            }

            _context.Wolf.Remove(wolf);
            await _context.SaveChangesAsync();

            return wolf;
        }

        

        private bool WolfExists(int id)
        {
            return _context.Wolf.Any(e => e.Id == id);
        }
    }
}
