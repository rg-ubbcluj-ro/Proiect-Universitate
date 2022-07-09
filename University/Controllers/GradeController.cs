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

    public class GradeController : ControllerBase
    {
        private readonly UniversityContext _context;
        
        public GradeController(UniversityContext context)
        {
            _context = context;
           
        }

        // GET: api/Grade
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GradeDTO>>> GetGradesItems(int? idStudent)
        {
            string userId = HttpContext?.User.Claims.FirstOrDefault(c => c.Type == "Id").Value;

            var currentLoggedInUser = _context.UsersItems.FirstOrDefault(c => c.Id == long.Parse(userId));
            var query = _context.GradesItems.AsQueryable();
            //query = query.Where(c => c.userInfo.Id == currentLoggedInUser.Id);

          if (_context.GradesItems == null)
          {
              return NotFound();
          }
             //var query = _context.GradesItems.AsQueryable();

        if (idStudent!=null)

        {
            query = query.Where(c => c.IdStudent == idStudent);
        }
          return await query.Include(student =>student.Student)
            .Include(teacher=>teacher.Teacher)
            .Include(session=>session.Session)
            .Include(course=>course.Course).Select(item => GradeMappers.GradeToDTO(item)).ToListAsync();
        }
        

        // GET: api/Grade/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GradeDTO>> GetGrade(int id)
        {
            string userId = HttpContext?.User.Claims.FirstOrDefault(c => c.Type == "Id").Value;
            var currentLoggedInUser = _context.UsersItems.FirstOrDefault(c => c.Id == long.Parse(userId));

          var gradeItem = await _context.GradesItems.FirstOrDefaultAsync(c => c.Id == id);  

          if (_context.GradesItems == null)
          {
              return NotFound();
          }
            var grade = _context.GradesItems.Include(student =>student.Student)
            .Include(teacher=>teacher.Teacher)
            .Include(session=>session.Session)
            .Include(course=>course.Course).FirstOrDefault(c => c.Id == id);

            if (grade == null)
            {
                return NotFound();
            }

            return GradeMappers.GradeToDTO(grade);
        }

        // PUT: api/Grade/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGrade(int id, Grade grade)
        {
            if (id != grade.Id)
            {
                return BadRequest();
            }
            string userId = HttpContext?.User.Claims.FirstOrDefault(c => c.Type == "Id").Value;
            var currentLoggedInUser = _context.UsersItems.FirstOrDefault(c => c.Id == long.Parse(userId));
            //grade.userInfo = currentLoggedInUser;

            _context.Entry(grade).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GradeExists(id))
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

        // POST: api/Grade
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GradeDTO>> PostGrade(GradeDTO gradeDTO)
        {
        string userId = HttpContext?.User.Claims.FirstOrDefault(c => c.Type == "Id").Value;

        var currentLoggedInUser = _context.UsersItems.FirstOrDefault(c => c.Id == long.Parse(userId));


        var gradeToAdd = GradeMappers.DTOtoGrade(gradeDTO);

        //gradeToAdd.userInfo = currentLoggedInUser;

        
            _context.GradesItems.Add(gradeToAdd);
        //   if (_context.GradesItems == null)
        //   {
        //       return Problem("Entity set 'UniversityContext.GradesItems'  is null.");
        //   }
        //     //grade.Student = _studentController.GetStudentById(grade.IdStudent);
        //     _context.GradesItems.Add(grade);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGrade), new { id = gradeDTO.Id }, GradeMappers.GradeToDTO(gradeToAdd));
        }

        // DELETE: api/Grade/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGrade(int id)
        {
            if (_context.GradesItems == null)
            {
                return NotFound();
            }
            string userId = HttpContext?.User.Claims.FirstOrDefault(c => c.Type == "Id").Value;

            var currentLoggedInUser = _context.UsersItems.FirstOrDefault(c => c.Id == long.Parse(userId));

            var grade = await _context.GradesItems.FindAsync(id);
            if (grade == null)
            {
                return NotFound();
            }

            _context.GradesItems.Remove(grade);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GradeExists(int id)
        {
            return (_context.GradesItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
