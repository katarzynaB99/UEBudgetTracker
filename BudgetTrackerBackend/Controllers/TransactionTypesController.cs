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
    public class TransactionTypesController : ControllerBase
    {
        private readonly BudgetTrackerContext _context;

        public TransactionTypesController(BudgetTrackerContext context)
        {
            _context = context;
        }

        // GET: api/TransactionTypes
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<TransactionType>>> GetTransactionType()
        {
            return await _context.TransactionType.ToListAsync();
        }

        // GET: api/TransactionTypes/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<TransactionType>> GetTransactionType(long id)
        {
            var transactionType = await _context.TransactionType.FindAsync(id);

            if (transactionType == null)
            {
                return NotFound();
            }

            return transactionType;
        }

        // PUT: api/TransactionTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutTransactionType(long id, TransactionType transactionType)
        {
            if (id != transactionType.Id)
            {
                return BadRequest();
            }

            _context.Entry(transactionType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransactionTypeExists(id))
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

        // POST: api/TransactionTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<TransactionType>> PostTransactionType(TransactionType transactionType)
        {
            _context.TransactionType.Add(transactionType);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TransactionTypeExists(transactionType.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTransactionType", new { id = transactionType.Id }, transactionType);
        }

        // DELETE: api/TransactionTypes/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<TransactionType>> DeleteTransactionType(long id)
        {
            var transactionType = await _context.TransactionType.FindAsync(id);
            if (transactionType == null)
            {
                return NotFound();
            }

            _context.TransactionType.Remove(transactionType);
            await _context.SaveChangesAsync();

            return transactionType;
        }

        private bool TransactionTypeExists(long id)
        {
            return _context.TransactionType.Any(e => e.Id == id);
        }
    }
}
