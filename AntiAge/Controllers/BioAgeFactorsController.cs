using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AntiAge.Data;
using AntiAge.Data.Entities;

namespace AntiAge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BioAgeFactorsController : ControllerBase
    {
        private readonly AntiAgeContext _context;

        public BioAgeFactorsController(AntiAgeContext context)
        {
            _context = context;
        }

        // GET: api/BioAgeFactors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BioAgeFactor>>> GetBioAgeFactors()
        {
            return await _context.BioAgeFactors.ToListAsync();
        }

        // GET: api/BioAgeFactors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BioAgeFactor>> GetBioAgeFactor(int id)
        {
            var bioAgeFactor = await _context.BioAgeFactors.FindAsync(id);

            if (bioAgeFactor == null)
            {
                return NotFound();
            }

            return bioAgeFactor;
        }

        // PUT: api/BioAgeFactors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBioAgeFactor(int id, BioAgeFactor bioAgeFactor)
        {
            if (id != bioAgeFactor.FactorId)
            {
                return BadRequest();
            }

            _context.Entry(bioAgeFactor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BioAgeFactorExists(id))
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

        // POST: api/BioAgeFactors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BioAgeFactor>> PostBioAgeFactor(BioAgeFactor bioAgeFactor)
        {
            _context.BioAgeFactors.Add(bioAgeFactor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBioAgeFactor", new { id = bioAgeFactor.FactorId }, bioAgeFactor);
        }

        // DELETE: api/BioAgeFactors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBioAgeFactor(int id)
        {
            var bioAgeFactor = await _context.BioAgeFactors.FindAsync(id);
            if (bioAgeFactor == null)
            {
                return NotFound();
            }

            _context.BioAgeFactors.Remove(bioAgeFactor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BioAgeFactorExists(int id)
        {
            return _context.BioAgeFactors.Any(e => e.FactorId == id);
        }
    }
}
