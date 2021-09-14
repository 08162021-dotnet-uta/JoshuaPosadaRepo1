using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project1.ModelsLayer.EfModels;
using Project1.StoreApplication.Storage.Models;

namespace Project1.StoreApplication.Storage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoresProductsController : ControllerBase
    {
        private readonly Demo_08162021batchContext _context;

        public StoresProductsController(Demo_08162021batchContext context)
        {
            _context = context;
        }

        // GET: api/StoresProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StoresProduct>>> GetStoresProducts()
        {
            return await _context.StoresProducts.ToListAsync();
        }

        // GET: api/StoresProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StoresProduct>> GetStoresProduct(int id)
        {
            var storesProduct = await _context.StoresProducts.FindAsync(id);

            if (storesProduct == null)
            {
                return NotFound();
            }

            return storesProduct;
        }

        // PUT: api/StoresProducts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStoresProduct(int id, StoresProduct storesProduct)
        {
            if (id != storesProduct.StoreProductId)
            {
                return BadRequest();
            }

            _context.Entry(storesProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StoresProductExists(id))
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

        // POST: api/StoresProducts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StoresProduct>> PostStoresProduct(StoresProduct storesProduct)
        {
            _context.StoresProducts.Add(storesProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStoresProduct", new { id = storesProduct.StoreProductId }, storesProduct);
        }

        // DELETE: api/StoresProducts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStoresProduct(int id)
        {
            var storesProduct = await _context.StoresProducts.FindAsync(id);
            if (storesProduct == null)
            {
                return NotFound();
            }

            _context.StoresProducts.Remove(storesProduct);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StoresProductExists(int id)
        {
            return _context.StoresProducts.Any(e => e.StoreProductId == id);
        }
    }
}
