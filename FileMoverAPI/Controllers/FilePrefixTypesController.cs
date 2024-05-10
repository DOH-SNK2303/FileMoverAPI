using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FileMoverAPI.Models;

namespace FileMoverAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilePrefixTypesController : ControllerBase
    {
        private readonly ServicesContext _context;

        public FilePrefixTypesController(ServicesContext context)
        {
            _context = context;
        }

        // GET: api/FilePrefixTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FilePrefixType>>> GetFilePrefixTypes()
        {
            return await _context.FilePrefixTypes.ToListAsync();
        }

        // GET: api/FilePrefixTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FilePrefixType>> GetFilePrefixType(int id)
        {
            var filePrefixType = await _context.FilePrefixTypes.FindAsync(id);

            if (filePrefixType == null)
            {
                return NotFound();
            }

            return filePrefixType;
        }

        // PUT: api/FilePrefixTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFilePrefixType(int id, FilePrefixType filePrefixType)
        {
            if (id != filePrefixType.FilePrefixTypeId)
            {
                return BadRequest();
            }

            _context.Entry(filePrefixType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilePrefixTypeExists(id))
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

        // POST: api/FilePrefixTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FilePrefixType>> PostFilePrefixType(FilePrefixType filePrefixType)
        {
            _context.FilePrefixTypes.Add(filePrefixType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFilePrefixType", new { id = filePrefixType.FilePrefixTypeId }, filePrefixType);
        }

        // DELETE: api/FilePrefixTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFilePrefixType(int id)
        {
            var filePrefixType = await _context.FilePrefixTypes.FindAsync(id);
            if (filePrefixType == null)
            {
                return NotFound();
            }

            _context.FilePrefixTypes.Remove(filePrefixType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FilePrefixTypeExists(int id)
        {
            return _context.FilePrefixTypes.Any(e => e.FilePrefixTypeId == id);
        }
    }
}
