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

    public class StudentController : ControllerBase
    {
        private readonly UniversityContext _context;

        public StudentController(UniversityContext context)
        {
            _context = context;
        }

        // GET: api/Student
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDTO>>> GetStudentsItems()
        {
            string userId = HttpContext?.User.Claims.FirstOrDefault(c => c.Type == "Id").Value;

            var currentLoggedInUser = _context.UsersItems.FirstOrDefault(c => c.Id == long.Parse(userId));
            var query = _context.StudentsItems.AsQueryable();
            //query = query.Where(c => c.UserInfo.Id == currentLoggedInUser.Id);

        //   if (_context.StudentsItems == null)
        //   {
        //       return NotFound();
        //   }
        //     return await _context.StudentsItems.ToListAsync();
        return await query.Select(item => StudentMappers.StudentToDTO(item)).ToListAsync();

        }
        
        // GET: api/Student/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDTO>> GetStudent(int id)
        {
            string userId = HttpContext?.User.Claims.FirstOrDefault(c => c.Type == "Id").Value;
            var currentLoggedInUser = _context.UsersItems.FirstOrDefault(c => c.Id == long.Parse(userId));

          var studentItem = await _context.StudentsItems.FirstOrDefaultAsync(c => c.Id == id );  

          if (_context.StudentsItems == null)
          {
              return NotFound();
          }
            var student = _context.StudentsItems.FirstOrDefault(c => c.Id == id);

            if (student == null)
            {
                return NotFound();
            }

            return StudentMappers.StudentToDTO(student);
        }

        public Student GetStudentById(int id)
        {
            return _context.StudentsItems.FirstOrDefault(s => s.Id == id);
        }
        // PUT: api/Student/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, Student student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }
            string userId = HttpContext?.User.Claims.FirstOrDefault(c => c.Type == "Id").Value;
            var currentLoggedInUser = _context.UsersItems.FirstOrDefault(c => c.Id == long.Parse(userId));
            //student.userInfo = currentLoggedInUser;

            _context.Entry(student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
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

        // POST: api/Student
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudentDTO>> PostStudent(StudentDTO studentDTO)
        {
          if (_context.StudentsItems == null)
          {
              return Problem("Entity set 'UniversityContext.StudentsItems'  is null.");
          }
        string userId = HttpContext?.User.Claims.FirstOrDefault(c => c.Type == "Id").Value;

        var currentLoggedInUser = _context.UsersItems.FirstOrDefault(c => c.Id == long.Parse(userId));

        if(currentLoggedInUser.Role=="admin"){ 
        var studentToAdd = StudentMappers.DTOtoStudent(studentDTO);

        //studentToAdd.userInfo = currentLoggedInUser;

            _context.StudentsItems.Add(studentToAdd);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStudent), new { id = studentDTO.Id }, StudentMappers.StudentToDTO(studentToAdd));
        }
        else{
            return BadRequest("You are not authorized to add a student");
        }
        }

        // DELETE: api/Student/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            if (_context.StudentsItems == null)
            {
                return NotFound();
            }
            string userId = HttpContext?.User.Claims.FirstOrDefault(c => c.Type == "Id").Value;

            var currentLoggedInUser = _context.UsersItems.FirstOrDefault(c => c.Id == long.Parse(userId));

            var student = await _context.StudentsItems.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.StudentsItems.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentExists(int id)
        {
            return (_context.StudentsItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
