using University.Models;
using University.DTOs;
namespace University.Mappers;   

public static class TeacherMappers
{
    public static TeacherDTO TeacherToDTO(Teacher teacher) =>
        new TeacherDTO()
        {
            Id = teacher.Id,
            Email = teacher.Email,
            DidacticRole = teacher.DidacticRole,
        };

    public static Teacher DTOtoTeacher(TeacherDTO teacherDTO) =>
        new Teacher()
        {
            Id = teacherDTO.Id,
            Email = teacherDTO.Email,
            DidacticRole = teacherDTO.DidacticRole,
        };
}