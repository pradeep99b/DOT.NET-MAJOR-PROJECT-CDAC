using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MedLab.Models;

namespace MedLab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestCategoriesController : ControllerBase
    {
        private readonly MedLabContext _context;

        public TestCategoriesController(MedLabContext context)
        {
            _context = context;
        }

        // GET: api/TestCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TestCategory>>> GetTestCategory()
        {
            return await _context.TestCategory.ToListAsync();
        }

        // GET: api/TestCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TestCategory>> GetTestCategory(int id)
        {
            var testCategory = await _context.TestCategory.FindAsync(id);

            if (testCategory == null)
            {
                return NotFound();
            }

            return testCategory;
        }

        // PUT: api/TestCategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTestCategory(int id, TestCategory testCategory)
        {
            if (id != testCategory.CategoryID)
            {
                return BadRequest();
            }

            _context.Entry(testCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestCategoryExists(id))
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

        // POST: api/TestCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TestCategory>> PostTestCategory(TestCategory testCategory)
        {
            _context.TestCategory.Add(testCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTestCategory", new { id = testCategory.CategoryID }, testCategory);
        }

        // DELETE: api/TestCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestCategory(int id)
        {
            var testCategory = await _context.TestCategory.FindAsync(id);
            if (testCategory == null)
            {
                return NotFound();
            }

            _context.TestCategory.Remove(testCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TestCategoryExists(int id)
        {
            return _context.TestCategory.Any(e => e.CategoryID == id);
        }
    }
}
