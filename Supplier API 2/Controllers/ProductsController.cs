using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Supplier_API_2.Data;
using Supplier_API_2.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supplier_API_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        [HttpGet("code/{productCode}")]
        public async Task<ActionResult<Product>> GetProductByCode(string productCode)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.ProductCode == productCode);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProductByCode), new { productCode = product.ProductCode }, product);
        }

        [HttpPut("update/{productCode}")]
        public async Task<IActionResult> UpdateProduct(string productCode, Product updatedProduct)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.ProductCode == productCode);

            if (product == null)
            {
                return NotFound();
            }

            product.Name = updatedProduct.Name;
            product.Description = updatedProduct.Description;
            product.Price = updatedProduct.Price;
            product.Stock = updatedProduct.Stock;

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExistsByCode(productCode))
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

        [HttpPut("update-price/{productCode}")]
        public async Task<IActionResult> UpdatePrice(string productCode, [FromBody] decimal newPrice)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.ProductCode == productCode);
            if (product == null)
            {
                return NotFound();
            }

            product.Price = newPrice;
            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExistsByCode(productCode))
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

        [HttpPut("update-stock/{productCode}")]
        public async Task<IActionResult> UpdateStock(string productCode, [FromBody] int newStock)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.ProductCode == productCode);
            if (product == null)
            {
                return NotFound();
            }

            product.Stock = newStock;
            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExistsByCode(productCode))
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

        [HttpGet("details/{productName}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsByName(string productName)
        {
            var products = await _context.Products
                .Where(p => EF.Functions.Like(p.Name, $"%{productName}%"))
                .ToListAsync();

            if (products == null || !products.Any())
            {
                return NotFound();
            }

            return Ok(products);
        }

        [HttpDelete("code/{productCode}")]
        public async Task<IActionResult> DeleteProduct(string productCode)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.ProductCode == productCode);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExistsByCode(string productCode)
        {
            return _context.Products.Any(p => p.ProductCode == productCode);
        }
    }
}
