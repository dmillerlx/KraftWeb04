using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KraftWeb04.Models;

namespace KraftWeb04.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailyGainsLossesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DailyGainsLossesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/DailyGainsLosses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DailyGainsLosses>>> GetDailyGainsLosses()
        {
            return await _context.DailyGainsLosses.ToListAsync();
        }

        // GET: api/DailyGainsLosses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DailyGainsLosses>> GetDailyGainsLosses(int id)
        {
            var dailyGainsLosses = await _context.DailyGainsLosses.FindAsync(id);

            if (dailyGainsLosses == null)
            {
                return NotFound();
            }

            return dailyGainsLosses;
        }

        // PUT: api/DailyGainsLosses/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDailyGainsLosses(int id, DailyGainsLosses dailyGainsLosses)
        {
            if (id != dailyGainsLosses.Id)
            {
                return BadRequest();
            }

            _context.Entry(dailyGainsLosses).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DailyGainsLossesExists(id))
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

        // POST: api/DailyGainsLosses
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<DailyGainsLosses>> PostDailyGainsLosses(DailyGainsLosses dailyGainsLosses)
        {
            _context.DailyGainsLosses.Add(dailyGainsLosses);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDailyGainsLosses", new { id = dailyGainsLosses.Id }, dailyGainsLosses);
        }

        // DELETE: api/DailyGainsLosses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DailyGainsLosses>> DeleteDailyGainsLosses(int id)
        {
            var dailyGainsLosses = await _context.DailyGainsLosses.FindAsync(id);
            if (dailyGainsLosses == null)
            {
                return NotFound();
            }

            _context.DailyGainsLosses.Remove(dailyGainsLosses);
            await _context.SaveChangesAsync();

            return dailyGainsLosses;
        }

        private bool DailyGainsLossesExists(int id)
        {
            return _context.DailyGainsLosses.Any(e => e.Id == id);
        }
    }
}
