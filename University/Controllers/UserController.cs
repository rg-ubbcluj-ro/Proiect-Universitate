using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using University.Models;
using University.DTOs;
using University.Mappers;
using System.Security.Claims;

namespace University.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly UniversityContext _context;

        public UserController(UniversityContext context)
        {
            _context = context;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserInfo>>> GetUsersItems()
        {
          if (_context.UsersItems == null)
          {
              return NotFound();
          }
            return await _context.UsersItems.ToListAsync();
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserInfo>> GetUser(int id)
        {
          if (_context.UsersItems == null)
          {
              return NotFound();
          }
            var user = await _context.UsersItems.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/User/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, UserInfo user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/User
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserInfo>> PostUser(UserInfo user)
        {
          if (_context.UsersItems == null)
          {
              return Problem("Entity set 'UniversityContext.UsersItems'  is null.");
          }
            _context.UsersItems.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (_context.UsersItems == null)
            {
                return NotFound();
            }
            var user = await _context.UsersItems.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.UsersItems.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return (_context.UsersItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
