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
    public class HoldingsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public HoldingsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Holdings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Holdings>>> GetHoldings()
        {
            return await _context.Holdings.ToListAsync();
        }

        // GET: api/Holdings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Holdings>> GetHoldings(int id)
        {
            var holdings = await _context.Holdings.FindAsync(id);

            if (holdings == null)
            {
                return NotFound();
            }

            return holdings;
        }

        // PUT: api/Holdings/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHoldings(int id, Holdings holdings)
        {
            if (id != holdings.Id)
            {
                return BadRequest();
            }

            _context.Entry(holdings).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HoldingsExists(id))
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

        // POST: api/Holdings
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Holdings>> PostHoldings(Holdings holdings)
        {
            _context.Holdings.Add(holdings);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHoldings", new { id = holdings.Id }, holdings);
        }

        // DELETE: api/Holdings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Holdings>> DeleteHoldings(int id)
        {
            var holdings = await _context.Holdings.FindAsync(id);
            if (holdings == null)
            {
                return NotFound();
            }

            _context.Holdings.Remove(holdings);
            await _context.SaveChangesAsync();

            return holdings;
        }

        private bool HoldingsExists(int id)
        {
            return _context.Holdings.Any(e => e.Id == id);
        }
    }
}
