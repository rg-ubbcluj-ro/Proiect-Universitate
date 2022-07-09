using University.Models;
using University.DTOs;
namespace University.Mappers;   

public static class SessionMappers
{
        public static SessionDTO SessionToDTO(Session session) =>
        new SessionDTO()
        {
            Id = session.Id,
            Type = session.Type,
            UniversityYear = session.UniversityYear,
            Semester = session.Semester,
            StartDate = session.StartDate,
            EndDate = session.EndDate,
        };

    public static Session DTOtoSession(SessionDTO sessionDTO) =>
        new Session()
        {
            Id = sessionDTO.Id,
            Type = sessionDTO.Type,
            UniversityYear = sessionDTO.UniversityYear,
            Semester = sessionDTO.Semester,
            StartDate = sessionDTO.StartDate,
            EndDate = sessionDTO.EndDate,
        };
}