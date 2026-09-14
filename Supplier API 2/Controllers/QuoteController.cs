using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Supplier_API_2.Data;
using Supplier_API_2.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supplier_API_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public QuotesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("place")]
        public async Task<ActionResult<Quote>> PlaceQuote([FromBody] QuoteRequest quoteRequest)
        {
            var quote = quoteRequest.Quote;
            var quoteItems = quoteRequest.Quote.QuoteItems;

            if (quoteItems == null || !quoteItems.Any())
            {
                return BadRequest("Qrder must contain at least one item.");
            }

            var productCodes = quoteItems.Select(item => item.ProductCode).ToList();

            var products = await _context.Products
            .Where(p => productCodes.Contains(p.ProductCode))
            .ToListAsync();

            if (products.Count != productCodes.Count)
            {
                return BadRequest("One or more products are not found.");
            }

            foreach (var item in quoteItems)
            {
                var product = products.FirstOrDefault(p => p.ProductCode == item.ProductCode);

                if (product == null)
                {
                    return BadRequest($"Product with code {item.ProductCode} not found.");
                }
            }

            _context.Quotes.Add(quote);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetQuoteById), new { id = quote.QuoteId }, quote);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Quote>> GetQuoteById(int id)
        {
            var quote = await _context.Quotes.Include(o => o.QuoteItems).FirstOrDefaultAsync(o => o.QuoteId == id);

            if (quote == null)
            {
                return NotFound();
            }

            return quote;
        }

        [HttpPut("update-status/{id}")]
        public async Task<IActionResult> UpdateQuoteStatus(int id, [FromBody] string newStatus)
        {
            var quote = await _context.Quotes.FirstOrDefaultAsync(o => o.QuoteId == id);
            if (quote == null)
            {
                return NotFound();
            }

            quote.Status = newStatus;
            _context.Entry(quote).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuoteExists(id))
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

        private bool QuoteExists(int id)
        {
            return _context.Quotes.Any(o => o.QuoteId == id);
        }
    }

}

public class QuoteRequest
{
    public Quote Quote { get; set; }
}
