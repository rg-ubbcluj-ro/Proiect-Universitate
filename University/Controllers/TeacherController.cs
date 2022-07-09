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

    public class TeacherController : ControllerBase
    {
        private readonly UniversityContext _context;

        public TeacherController(UniversityContext context)
        {
            _context = context;
        }

        // GET: api/Teacher
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeacherDTO>>> GetTeachersItems()
        {
            string userId = HttpContext?.User.Claims.FirstOrDefault(c => c.Type == "Id").Value;

            var currentLoggedInUser = _context.UsersItems.FirstOrDefault(c => c.Id == long.Parse(userId));
            if(currentLoggedInUser.Role=="admin" || currentLoggedInUser.Role=="adminSistem")
            {
            var query = _context.TeachersItems.AsQueryable();
            //query = query.Where(c => c.userInfo.Id == currentLoggedInUser.Id);

            return await query.Include(UserInfo => UserInfo.UserInfo).Select(item => TeacherMappers.TeacherToDTO(item)).ToListAsync();
            }
            else
            {
                return Unauthorized("You are not authorized to view a teacher. You are not a admin or adminSistem");
            }
        }

        // GET: api/Teacher/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TeacherDTO>> GetTeacher(int id)
        {
            string userId = HttpContext?.User.Claims.FirstOrDefault(c => c.Type == "Id").Value;
            var currentLoggedInUser = _context.UsersItems.FirstOrDefault(c => c.Id == long.Parse(userId));
          if(currentLoggedInUser.Role=="admin" || currentLoggedInUser.Role=="adminSistem")
            {
          var teacherItem = await _context.TeachersItems.FirstOrDefaultAsync(c => c.Id == id);  

          if (_context.TeachersItems == null)
          {
              return NotFound();
          }
            var teacher = _context.TeachersItems.FirstOrDefault(c => c.Id == id);
            if (teacher == null)
            {
                return NotFound();
            }
            return TeacherMappers.TeacherToDTO(teacher);
            }
            else
            {
                return Unauthorized("You are not authorized to view a teacher. You are not a admin or adminSistem");
            }
        }

        // PUT: api/Teacher/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeacher(int id, Teacher teacher)
        {
            if (id != teacher.Id)
            {
                return BadRequest();
            }
            string userId = HttpContext?.User.Claims.FirstOrDefault(c => c.Type == "Id").Value;
            var currentLoggedInUser = _context.UsersItems.FirstOrDefault(c => c.Id == long.Parse(userId));
            //teacher.userInfo = currentLoggedInUser;

            if(currentLoggedInUser.Role=="admin" || currentLoggedInUser.Role=="adminSistem")
            {
            _context.Entry(teacher).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeacherExists(id))
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
                return Unauthorized("You are not authorized to edit a teacher. You are not a admin or adminSistem");
            }
        }

        // POST: api/Teacher
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TeacherDTO>> PostTeacher(TeacherDTO teacherDTO)
        {
          if (_context.TeachersItems == null)
          {
              return Problem("Entity set 'UniversityContext.TeachersItems'  is null.");
          }
        string userId = HttpContext?.User.Claims.FirstOrDefault(c => c.Type == "Id").Value;

        var currentLoggedInUser = _context.UsersItems.FirstOrDefault(c => c.Id == long.Parse(userId));
        if(currentLoggedInUser.Role=="admin" || currentLoggedInUser.Role=="adminSistem")
            {
       var teachertoAdd = TeacherMappers.DTOtoTeacher(teacherDTO); 
        //var teacherToAdd = TeacherMappers.TeacherToDTO(teacherDTO);

        //teacherToAdd.userInfo = currentLoggedInUser;

            _context.TeachersItems.Add(teachertoAdd);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTeacher), new { id = teacherDTO.Id }, TeacherMappers.TeacherToDTO(teachertoAdd));
            }
            else
            {
                return Unauthorized("You are not authorized to add a teacher. You are not a admin or adminSistem");
            }
        }

        // DELETE: api/Teacher/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacher(int id)
        {
            if (_context.TeachersItems == null)
            {
                return NotFound();
            }

            string userId = HttpContext?.User.Claims.FirstOrDefault(c => c.Type == "Id").Value;

            var currentLoggedInUser = _context.UsersItems.FirstOrDefault(c => c.Id == long.Parse(userId));
            if(currentLoggedInUser.Role=="admin" || currentLoggedInUser.Role=="adminSistem")
            {
            var teacher = await _context.TeachersItems.FindAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }

            _context.TeachersItems.Remove(teacher);
            await _context.SaveChangesAsync();

            return NoContent();
            }
            else
            {
                return Unauthorized("You are not authorized to delete a teacher. You are not a admin or adminSistem");
            }
        }

        private bool TeacherExists(int id)
        {
            return (_context.TeachersItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
