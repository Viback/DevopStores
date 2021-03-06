﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testApp;

namespace testApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoriesController : ControllerBase
    {
        private readonly d22t8omvseiqtsContext _context;

        public InventoriesController(d22t8omvseiqtsContext context)
        {
            _context = context;
        }

        // GET: api/Inventories
        [HttpGet]
        public IEnumerable<Inventory> GetInventory()
        {
            var inventory = _context.Inventory;
            //product.Entity<Product>().Ignore(e => e.image);

            return inventory;
        }

        [HttpGet("{stores}")]
        public IActionResult GetInventory([FromRoute] string stores)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var inventory = _context.Inventory.Select(e => new { e.StoreId, e.ProdId, e.Qty }).ToList();
            //var no_id = inventory.Select(e => new { e.StoreId, e.Qty, e.ProdId }).ToList();
            if (inventory == null)
            {
                return NotFound();
            }

            return Ok(inventory);
        }

        // GET: api/Inventories/store_id
        [HttpGet("stores/{id}")]
        public IActionResult GetInventory([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var inventory = _context.Inventory.Where(e => e.StoreId.Equals(id)).ToList();
            //var no_id = inventory.Select(e => new { e.StoreId, e.Qty, e.ProdId }).ToList();
            if (inventory == null)
            {
                return NotFound();
            }

            return Ok(inventory);
        }
        // GET: api/Inventories/store_id/prod_id
        [HttpGet("stores/{id}/{p_id}")]
        public IActionResult GetInventory([FromRoute] int id ,int p_id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var inventory = _context.Inventory.Where(e => e.StoreId.Equals(id)).ToList();
            var prod = inventory.Where(e => e.ProdId.Equals(p_id)).ToList();
            //var no_id = prod.Select(e => new { e.StoreId, e.Qty, e.ProdId }).ToList();

            if (prod == null)
            {
                return NotFound();
            }

            return Ok(prod);
        }


        /* [HttpGet("{StoreId}")]
         public string GetQuery(string Id, string StoreId, string ProdId, string Qty)
         {
             return $"{Id}:{StoreId}:{ProdId}:{Qty}";
         }*/


        // PUT: api/Inventories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInventory([FromRoute] int id, [FromBody] Inventory inventory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != inventory.Id)
            {
                return BadRequest();
            }

            _context.Entry(inventory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventoryExists(id))
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

        // POST: api/Inventories
        [HttpPost]
        public async Task<IActionResult> PostInventory([FromBody] Inventory inventory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Inventory.Add(inventory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInventory", new { id = inventory.Id }, inventory);
        }

        // DELETE: api/Inventories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInventory([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var inventory = await _context.Inventory.FindAsync(id);
            if (inventory == null)
            {
                return NotFound();
            }

            _context.Inventory.Remove(inventory);
            await _context.SaveChangesAsync();

            return Ok(inventory);
        }

        private bool InventoryExists(int id)
        {
            return _context.Inventory.Any(e => e.Id == id);
        }
    }
}