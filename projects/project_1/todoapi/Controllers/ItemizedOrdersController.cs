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
    public class ItemizedOrdersController : ControllerBase
    {
        private readonly Demo_08162021batchContext _context;

        public ItemizedOrdersController(Demo_08162021batchContext context)
        {
            _context = context;
        }

        // GET: api/ItemizedOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemizedOrder>>> GetItemizedOrders()
        {
            return await _context.ItemizedOrders.ToListAsync();
        }

        // GET: api/ItemizedOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemizedOrder>> GetItemizedOrder(Guid id)
        {
            var itemizedOrder = await _context.ItemizedOrders.FindAsync(id);

            if (itemizedOrder == null)
            {
                return NotFound();
            }

            return itemizedOrder;
        }

        // PUT: api/ItemizedOrders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItemizedOrder(Guid id, ItemizedOrder itemizedOrder)
        {
            if (id != itemizedOrder.ItemizedId)
            {
                return BadRequest();
            }

            _context.Entry(itemizedOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemizedOrderExists(id))
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

        // POST: api/ItemizedOrders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ItemizedOrder>> PostItemizedOrder(ItemizedOrder itemizedOrder)
        {
            _context.ItemizedOrders.Add(itemizedOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItemizedOrder", new { id = itemizedOrder.ItemizedId }, itemizedOrder);
        }

        // DELETE: api/ItemizedOrders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemizedOrder(Guid id)
        {
            var itemizedOrder = await _context.ItemizedOrders.FindAsync(id);
            if (itemizedOrder == null)
            {
                return NotFound();
            }

            _context.ItemizedOrders.Remove(itemizedOrder);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ItemizedOrderExists(Guid id)
        {
            return _context.ItemizedOrders.Any(e => e.ItemizedId == id);
        }
    }
}
