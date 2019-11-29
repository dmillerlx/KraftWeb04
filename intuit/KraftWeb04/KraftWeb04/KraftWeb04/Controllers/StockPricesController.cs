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
    public class StockPricesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StockPricesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/StockPrices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StockPrice>>> GetStockPrice()
        {
            return await _context.StockPrice.ToListAsync();
        }

        // GET: api/StockPrices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StockPrice>> GetStockPrice(int id)
        {
            var stockPrice = await _context.StockPrice.FindAsync(id);

            if (stockPrice == null)
            {
                return NotFound();
            }

            return stockPrice;
        }

        // PUT: api/StockPrices/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStockPrice(int id, StockPrice stockPrice)
        {
            if (id != stockPrice.Id)
            {
                return BadRequest();
            }

            _context.Entry(stockPrice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StockPriceExists(id))
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

        // POST: api/StockPrices
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<StockPrice>> PostStockPrice(StockPrice stockPrice)
        {
            _context.StockPrice.Add(stockPrice);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStockPrice", new { id = stockPrice.Id }, stockPrice);
        }

        // DELETE: api/StockPrices/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StockPrice>> DeleteStockPrice(int id)
        {
            var stockPrice = await _context.StockPrice.FindAsync(id);
            if (stockPrice == null)
            {
                return NotFound();
            }

            _context.StockPrice.Remove(stockPrice);
            await _context.SaveChangesAsync();

            return stockPrice;
        }

        private bool StockPriceExists(int id)
        {
            return _context.StockPrice.Any(e => e.Id == id);
        }
    }
}
