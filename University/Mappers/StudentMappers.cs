using University.Models;
using University.DTOs;
namespace University.Mappers;   

public static class StudentMappers 
{        public static StudentDTO StudentToDTO(Student student) =>
        new StudentDTO()
        {
            Id = student.Id,
            Email = student.Email,
            YearOfStudy = student.YearOfStudy,
            Specialization = student.Specialization,
            UserInfo = student.UserInfo == null ? null : UserInfoMappers.UserInfoToDTO(student.UserInfo),
        };

    public static Student DTOtoStudent(StudentDTO studentDTO) =>
        new Student()
        {
            Id = studentDTO.Id,
            Email = studentDTO.Email,
            YearOfStudy = studentDTO.YearOfStudy,
            Specialization = studentDTO.Specialization,
            UserInfo = studentDTO.UserInfo == null ? null : UserInfoMappers.DTOtoUserInfo(studentDTO.UserInfo),
        };
}