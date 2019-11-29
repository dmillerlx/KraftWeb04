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
    public class StockWatchesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StockWatchesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/StockWatches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StockWatch>>> GetStockWatch()
        {
            return await _context.StockWatch.ToListAsync();
        }

        // GET: api/StockWatches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StockWatch>> GetStockWatch(int id)
        {
            var stockWatch = await _context.StockWatch.FindAsync(id);

            if (stockWatch == null)
            {
                return NotFound();
            }

            return stockWatch;
        }

        // PUT: api/StockWatches/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStockWatch(int id, StockWatch stockWatch)
        {
            if (id != stockWatch.Id)
            {
                return BadRequest();
            }

            _context.Entry(stockWatch).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StockWatchExists(id))
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

        // POST: api/StockWatches
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<StockWatch>> PostStockWatch(StockWatch stockWatch)
        {
            _context.StockWatch.Add(stockWatch);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStockWatch", new { id = stockWatch.Id }, stockWatch);
        }

        // DELETE: api/StockWatches/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StockWatch>> DeleteStockWatch(int id)
        {
            var stockWatch = await _context.StockWatch.FindAsync(id);
            if (stockWatch == null)
            {
                return NotFound();
            }

            _context.StockWatch.Remove(stockWatch);
            await _context.SaveChangesAsync();

            return stockWatch;
        }

        private bool StockWatchExists(int id)
        {
            return _context.StockWatch.Any(e => e.Id == id);
        }
    }
}
