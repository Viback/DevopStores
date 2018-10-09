using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace testApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class stores_with_productController : ControllerBase
    {
        private readonly d22t8omvseiqtsContext _context;

        public stores_with_productController(d22t8omvseiqtsContext context)
        {
            _context = context;
        }

        //GET: api/stores_with_product/prod_id
        [HttpGet("{p_id}")]
        public IActionResult GetInventory([FromRoute] int p_id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var inventory = _context.Inventory.Where(e => e.ProdId.Equals(p_id)).ToList();
            var stores = inventory.Select(e => e.StoreId).ToList();
            
            if (stores == null)
            {
                return NotFound();
            }

            return Ok(stores);
        }
    }
}