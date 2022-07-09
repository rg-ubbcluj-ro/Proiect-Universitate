using University.Models;
using University.DTOs;
namespace University.Mappers;   

public static class GradeMappers
{
    public static GradeDTO GradeToDTO(Grade grade) =>
        new GradeDTO()
        {
            Id = grade.Id,
            IdStudent = grade.IdStudent,
            IdCourse = grade.IdCourse,
            GradeValue = grade.GradeValue,
            Student = grade.Student == null ? null : StudentMappers.StudentToDTO(grade.Student),
            Course = grade.Course == null ? null : CourseMappers.CourseToDTO(grade.Course),
            Session = grade.Session == null ? null : SessionMappers.SessionToDTO(grade.Session),
            Teacher = grade.Teacher == null ? null : TeacherMappers.TeacherToDTO(grade.Teacher),
        };

    public static Grade DTOtoGrade(GradeDTO gradeDTO) =>
        new Grade()
        {
            Id = gradeDTO.Id,
            IdStudent = gradeDTO.IdStudent,
            IdCourse = gradeDTO.IdCourse,
            GradeValue = gradeDTO.GradeValue,
            Student = gradeDTO.Student == null ? null : StudentMappers.DTOtoStudent(gradeDTO.Student),
            Course = gradeDTO.Course == null ? null : CourseMappers.DTOtoCourse(gradeDTO.Course),
            Session = gradeDTO.Session == null ? null : SessionMappers.DTOtoSession(gradeDTO.Session),
            Teacher = gradeDTO.Teacher == null ? null : TeacherMappers.DTOtoTeacher(gradeDTO.Teacher),
        };

}