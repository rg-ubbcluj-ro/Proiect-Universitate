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
    public class CourseController : ControllerBase
    {
        private readonly UniversityContext _context;

        public CourseController(UniversityContext context)
        {
            _context = context;
        }

        // GET: api/Course
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseDTO>>> GetCoursesItems()
        {
            string userId = HttpContext?.User.Claims.FirstOrDefault(c => c.Type == "Id").Value;

            var currentLoggedInUser = _context.UsersItems.FirstOrDefault(c => c.Id == long.Parse(userId));
            var query = _context.CoursesItems.AsQueryable();
            //query = query.Where(c => c.userInfo.Id == currentLoggedInUser.Id);
            return await query
            .Include(teacher=>teacher.Teacher).Select(item => CourseMappers.CourseToDTO(item)).ToListAsync();

        //   if (_context.CoursesItems == null)
        //   {
        //       return NotFound();
        //   }
        //     return await _context.CoursesItems.Include(teacher =>teacher.Teacher).ToListAsync();
        }

        // GET: api/Course/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<CourseDTO>>> GetCourse(int id)
        {
            string userId = HttpContext?.User.Claims.FirstOrDefault(c => c.Type == "Id").Value;
            var currentLoggedInUser = _context.UsersItems.FirstOrDefault(c => c.Id == long.Parse(userId));

          var courseItem = await _context.CoursesItems.FirstOrDefaultAsync(c => c.Id == id);  

          if (courseItem == null)
          {
              return NotFound();
          }
          //var course = _context.CoursesItems.Include(Teacher =>Teacher.Teacher).FirstOrDefault(c => c.Id == id);
            // var course = await _context.CoursesItems.FindAsync(id);

            // if (course == null)
            // {
            //     return NotFound();
            // }

            //return course;
            var query = _context.CoursesItems.AsQueryable();
           // return  CourseMappers.CourseToDTO(course);
            return await query
            .Include(teacher => teacher.Teacher).Select(item => CourseMappers.CourseToDTO(item)).ToListAsync();

        }

        // PUT: api/Course/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourse(int id, Course course)
        {
            if (id != course.Id)
            {
                return BadRequest();
            }

            string userId = HttpContext?.User.Claims.FirstOrDefault(c => c.Type == "Id").Value;
            var currentLoggedInUser = _context.UsersItems.FirstOrDefault(c => c.Id == long.Parse(userId));
            //course.userInfo = currentLoggedInUser;

            _context.Entry(course).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(id))
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

        // POST: api/Course
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CourseDTO>> PostCourse(CourseDTO courseDTO)
        {
            string userId = HttpContext?.User.Claims.FirstOrDefault(c => c.Type == "Id").Value;

        var currentLoggedInUser = _context.UsersItems.FirstOrDefault(c => c.Id == long.Parse(userId));


        var courseToAdd = CourseMappers.DTOtoCourse(courseDTO);

        //courseToAdd.userInfo = currentLoggedInUser;

          if (_context.CoursesItems == null)
          {
              return Problem("Entity set 'UniversityContext.CoursesItems'  is null.");
          }
            _context.CoursesItems.Add(courseToAdd);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCourse), new { id = courseDTO.Id }, CourseMappers.CourseToDTO(courseToAdd));
        }

        // DELETE: api/Course/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            
            string userId = HttpContext?.User.Claims.FirstOrDefault(c => c.Type == "Id").Value;

            var currentLoggedInUser = _context.UsersItems.FirstOrDefault(c => c.Id == long.Parse(userId));

            if (_context.CoursesItems == null)
            {
                return NotFound();
            }
            var course = await _context.CoursesItems.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            _context.CoursesItems.Remove(course);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CourseExists(int id)
        {
            return (_context.CoursesItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
