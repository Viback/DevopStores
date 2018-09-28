using System;
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
    public class TestproductsController : ControllerBase
    {
        private readonly d22t8omvseiqtsContext _context;

        public TestproductsController(d22t8omvseiqtsContext context)
        {
            _context = context;
        }

        // GET: api/Testproducts
        [HttpGet]
        public IEnumerable<Testproducts> GetTestproducts()
        {
            return _context.Testproducts;
        }

        // GET: api/Testproducts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTestproducts([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var testproducts = await _context.Testproducts.FindAsync(id);

            if (testproducts == null)
            {
                return NotFound();
            }

            return Ok(testproducts);
        }

        // PUT: api/Testproducts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTestproducts([FromRoute] int id, [FromBody] Testproducts testproducts)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != testproducts.ProdId)
            {
                return BadRequest();
            }

            _context.Entry(testproducts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestproductsExists(id))
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

        // POST: api/Testproducts
        [HttpPost]
        public async Task<IActionResult> PostTestproducts([FromBody] Testproducts testproducts)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Testproducts.Add(testproducts);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTestproducts", new { id = testproducts.ProdId }, testproducts);
        }

        // DELETE: api/Testproducts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestproducts([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var testproducts = await _context.Testproducts.FindAsync(id);
            if (testproducts == null)
            {
                return NotFound();
            }

            _context.Testproducts.Remove(testproducts);
            await _context.SaveChangesAsync();

            return Ok(testproducts);
        }

        private bool TestproductsExists(int id)
        {
            return _context.Testproducts.Any(e => e.ProdId == id);
        }
    }
}