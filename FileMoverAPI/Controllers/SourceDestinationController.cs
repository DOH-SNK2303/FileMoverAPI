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
    public class SourceDestinationController : ControllerBase
    {
        private readonly ServicesContext _context;

        public SourceDestinationController(ServicesContext context)
        {
            _context = context;
        }

        // GET: api/SourceDestination
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FileServer>>> GetFileServers()
        {
            return await _context.FileServers.ToListAsync();
        }

        // GET: api/SourceDestination/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FileServer>> GetFileServer(int id)
        {
            var fileServer = await _context.FileServers.FindAsync(id);

            if (fileServer == null)
            {
                return NotFound();
            }

            return fileServer;
        }

        // PUT: api/SourceDestination/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFileServer(int id, FileServer fileServer)
        {
            if (id != fileServer.Id)
            {
                return BadRequest();
            }

            _context.Entry(fileServer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FileServerExists(id))
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

        // POST: api/SourceDestination
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FileServer>> PostFileServer(FileServer fileServer)
        {
            _context.FileServers.Add(fileServer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFileServer", new { id = fileServer.Id }, fileServer);
        }

        // DELETE: api/SourceDestination/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFileServer(int id)
        {
            var fileServer = await _context.FileServers.FindAsync(id);
            if (fileServer == null)
            {
                return NotFound();
            }

            _context.FileServers.Remove(fileServer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FileServerExists(int id)
        {
            return _context.FileServers.Any(e => e.Id == id);
        }
    }
}
