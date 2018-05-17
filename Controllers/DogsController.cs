
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using workspace.Models;

namespace workspace.Controllers
{
    [Produces("application/json")]
    [Route("api/Dogs")]
    public class DogsController : Controller
    {
        private readonly DogsContext _context;

        public DogsController(DogsContext context)
        {
            _context = context;
        }

        // GET: api/Dogs
        [HttpGet]
        public IEnumerable<Dogs> GetDog()
        {
            return _context.Dog;
        }

        // GET: api/Dogs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDogs([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dogs = await _context.Dog.SingleOrDefaultAsync(m => m.Id == id);

            if (dogs == null)
            {
                return NotFound();
            }

            return Ok(dogs);
        }

        // PUT: api/Dogs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDogs([FromRoute] int id, [FromBody] Dogs dogs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dogs.Id)
            {
                return BadRequest();
            }

            _context.Entry(dogs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DogsExists(id))
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

        // POST: api/Dogs
        [HttpPost]
        public async Task<IActionResult> PostDogs([FromBody] Dogs dogs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Dog.Add(dogs);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDogs", new { id = dogs.Id }, dogs);
        }

        // DELETE: api/Dogs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDogs([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dogs = await _context.Dog.SingleOrDefaultAsync(m => m.Id == id);
            if (dogs == null)
            {
                return NotFound();
            }

            _context.Dog.Remove(dogs);
            await _context.SaveChangesAsync();

            return Ok(dogs);
        }

        private bool DogsExists(int id)
        {
            return _context.Dog.Any(e => e.Id == id);
        }
    }
}
