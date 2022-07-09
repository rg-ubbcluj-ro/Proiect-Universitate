using University.Models;
using University.DTOs;
namespace University.Mappers;   

public static class CourseMappers
{
        public static CourseDTO CourseToDTO(Course course) =>
        new CourseDTO()
        {
            Id = course.Id,
            IdTeacher = course.IdTeacher,
            CourseName = course.CourseName,
            Teacher = course.Teacher == null ? null : TeacherMappers.TeacherToDTO(course.Teacher),
            //Teacher = course.Teacher == null ? null : TeacherMappers.TeacherToDTO(course.Teacher),
        };

        public static Course DTOtoCourse(CourseDTO courseDTO) =>
        new Course()
        {
            Id = courseDTO.Id,
            IdTeacher = courseDTO.IdTeacher,
            CourseName = courseDTO.CourseName,
            Teacher = courseDTO.Teacher == null ? null : TeacherMappers.DTOtoTeacher(courseDTO.Teacher),
        };

}