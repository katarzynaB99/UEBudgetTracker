using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BudgetTrackerBackend.Models;
using Microsoft.AspNetCore.Authorization;

namespace BudgetTrackerBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillsController : ControllerBase
    {
        private readonly BudgetTrackerContext _context;

        public BillsController(BudgetTrackerContext context)
        {
            _context = context;
        }

        // GET: api/Bills
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Bill>>> GetBill()
        {
            return await _context.Bill.ToListAsync();
        }

        // GET: api/Bills/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Bill>> GetBill(long id)
        {
            var bill = await _context.Bill.FindAsync(id);

            if (bill == null)
            {
                return NotFound();
            }

            return bill;
        }

        // PUT: api/Bills/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutBill(long id, Bill bill)
        {
            if (id != bill.Id)
            {
                return BadRequest();
            }

            _context.Entry(bill).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BillExists(id))
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

        // POST: api/Bills
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Bill>> PostBill(Bill bill)
        {
            _context.Bill.Add(bill);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BillExists(bill.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBill", new { id = bill.Id }, bill);
        }

        // DELETE: api/Bills/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<Bill>> DeleteBill(long id)
        {
            var bill = await _context.Bill.FindAsync(id);
            if (bill == null)
            {
                return NotFound();
            }

            _context.Bill.Remove(bill);
            await _context.SaveChangesAsync();

            return bill;
        }

        private bool BillExists(long id)
        {
            return _context.Bill.Any(e => e.Id == id);
        }
    }
}
