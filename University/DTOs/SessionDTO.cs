namespace University.DTOs
{
    public class SessionDTO
    {
        public int Id { get; set; }
        public bool Type { get; set;}
        public string? UniversityYear {get; set;}
        public int Semester {get; set;}
        public DateTime StartDate {get; set;}
        public DateTime EndDate {get; set;}     
    }
}