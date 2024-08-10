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
    public class TestBookingsController : ControllerBase
    {
        private readonly MedLabContext _context;

        public TestBookingsController(MedLabContext context)
        {
            _context = context;
        }

        // GET: api/TestBookings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TestBooking>>> GetTestBooking()
        {
            return await _context.TestBooking.ToListAsync();
        }

        // GET: api/TestBookings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TestBooking>> GetTestBooking(int id)
        {
            var testBooking = await _context.TestBooking.FindAsync(id);

            if (testBooking == null)
            {
                return NotFound();
            }

            return testBooking;
        }

        // PUT: api/TestBookings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTestBooking(int id, TestBooking testBooking)
        {
            if (id != testBooking.BookingID)
            {
                return BadRequest();
            }

            _context.Entry(testBooking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestBookingExists(id))
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

        // POST: api/TestBookings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TestBooking>> PostTestBooking(TestBooking testBooking)
        {
            _context.TestBooking.Add(testBooking);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTestBooking", new { id = testBooking.BookingID }, testBooking);
        }

        // DELETE: api/TestBookings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestBooking(int id)
        {
            var testBooking = await _context.TestBooking.FindAsync(id);
            if (testBooking == null)
            {
                return NotFound();
            }

            _context.TestBooking.Remove(testBooking);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TestBookingExists(int id)
        {
            return _context.TestBooking.Any(e => e.BookingID == id);
        }
    }
}
