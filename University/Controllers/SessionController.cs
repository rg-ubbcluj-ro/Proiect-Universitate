using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using University.Models;
using University.DTOs;
using University.Mappers;
using System.Security.Claims;


namespace University.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class SessionController : ControllerBase
    {
        private readonly UniversityContext _context;

        public SessionController(UniversityContext context)
        {
            _context = context;
        }

        // GET: api/Session
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SessionDTO>>> GetSessionItems()
        {
            string userId = HttpContext?.User.Claims.FirstOrDefault(c => c.Type == "Id").Value;

            var currentLoggedInUser = _context.UsersItems.FirstOrDefault(c => c.Id == long.Parse(userId));
            if(currentLoggedInUser.Role=="adminSistem")
            { 
            var query = _context.SessionItems.AsQueryable();
            //query = query.Where(c => c.userInfo.Id == currentLoggedInUser.Id);
            return await query.Select(item => SessionMappers.SessionToDTO(item)).ToListAsync();
            }
            else 
            {
                return Unauthorized("You are not authorized to view a session. You are not a adminSistem");
            }
        }

        // GET: api/Session/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SessionDTO>> GetSession(int id)
        {
            string userId = HttpContext?.User.Claims.FirstOrDefault(c => c.Type == "Id").Value;
            var currentLoggedInUser = _context.UsersItems.FirstOrDefault(c => c.Id == long.Parse(userId));
          if(currentLoggedInUser.Role=="adminSistem")
            {  
          var sessionItem = await _context.SessionItems.FirstOrDefaultAsync(c => c.Id == id);  

          if (_context.SessionItems == null)
          {
              return NotFound();
          }
            var session = await _context.SessionItems.FirstOrDefaultAsync(c => c.Id == id);

            if (session == null)
            {
                return NotFound();
            }

            return SessionMappers.SessionToDTO(session);
            }
            else
            {
                return Unauthorized("You are not authorized to view a session. You are not a adminSistem");
            }
        }

        // PUT: api/Session/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSession(int id, Session session)
        {
            if (id != session.Id)
            {
                return BadRequest();
            }

            string userId = HttpContext?.User.Claims.FirstOrDefault(c => c.Type == "Id").Value;
            var currentLoggedInUser = _context.UsersItems.FirstOrDefault(c => c.Id == long.Parse(userId));
           if(currentLoggedInUser.Role=="adminSistem")
            { 
            _context.Entry(session).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SessionExists(id))
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
            else
            {
                return Unauthorized("You are not authorized to update a session. You are not a adminSistem");
            }
        }

        // POST: api/Session
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SessionDTO>> PostSession(SessionDTO sessionDTO)
        {
          if (_context.SessionItems == null)
          {
              return Problem("Entity set 'UniversityContext.SessionItems'  is null.");
          }
          string userId = HttpContext?.User.Claims.FirstOrDefault(c => c.Type == "Id").Value;

        var currentLoggedInUser = _context.UsersItems.FirstOrDefault(c => c.Id == long.Parse(userId));
        if(currentLoggedInUser.Role=="adminSistem")
            {  
        var sessionToAdd = SessionMappers.DTOtoSession(sessionDTO);

        //sessionToAdd.userInfo = currentLoggedInUser;


            _context.SessionItems.Add(sessionToAdd);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSession), new { id = sessionDTO.Id }, SessionMappers.SessionToDTO(sessionToAdd));
            }
            else
            {
                return Unauthorized("You are not authorized to add a session. You are not a adminSistem");
            }
        }

        // DELETE: api/Session/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSession(int id)
        {
            if (_context.SessionItems == null)
            {
                return NotFound();
            }
            string userId = HttpContext?.User.Claims.FirstOrDefault(c => c.Type == "Id").Value;

            var currentLoggedInUser = _context.UsersItems.FirstOrDefault(c => c.Id == long.Parse(userId));
            if(currentLoggedInUser.Role=="admin" || currentLoggedInUser.Role=="adminSistem")
            {   
            var session = await _context.SessionItems.FindAsync(id);
            if (session == null)
            {
                return NotFound();
            }

            _context.SessionItems.Remove(session);
            await _context.SaveChangesAsync();

            return NoContent();
            }
            else 
            {
                return Unauthorized("You are not authorized to delete a student. You are not a admin or adminSistem");
            }
        }

        private bool SessionExists(int id)
        {
            return (_context.SessionItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
