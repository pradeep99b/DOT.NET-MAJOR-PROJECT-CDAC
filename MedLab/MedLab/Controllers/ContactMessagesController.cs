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
    public class ContactMessagesController : ControllerBase
    {
        private readonly MedLabContext _context;

        public ContactMessagesController(MedLabContext context)
        {
            _context = context;
        }

        // GET: api/ContactMessages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactMessage>>> GetContactMessage()
        {
            return await _context.ContactMessage.ToListAsync();
        }

        // GET: api/ContactMessages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContactMessage>> GetContactMessage(int id)
        {
            var contactMessage = await _context.ContactMessage.FindAsync(id);

            if (contactMessage == null)
            {
                return NotFound();
            }

            return contactMessage;
        }

        // PUT: api/ContactMessages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContactMessage(int id, ContactMessage contactMessage)
        {
            if (id != contactMessage.MessageID)
            {
                return BadRequest();
            }

            _context.Entry(contactMessage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactMessageExists(id))
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

        // POST: api/ContactMessages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ContactMessage>> PostContactMessage(ContactMessage contactMessage)
        {
            _context.ContactMessage.Add(contactMessage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContactMessage", new { id = contactMessage.MessageID }, contactMessage);
        }

        // DELETE: api/ContactMessages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContactMessage(int id)
        {
            var contactMessage = await _context.ContactMessage.FindAsync(id);
            if (contactMessage == null)
            {
                return NotFound();
            }

            _context.ContactMessage.Remove(contactMessage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContactMessageExists(int id)
        {
            return _context.ContactMessage.Any(e => e.MessageID == id);
        }
    }
}
