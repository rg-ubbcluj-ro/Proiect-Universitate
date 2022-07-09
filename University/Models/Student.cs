namespace University.Models
{
    public class Student
    {
        //[Key]
        public int Id { get; set; }
        public string? Email { get; set;}
        public int YearOfStudy {get; set;}
        public string? Specialization {get; set;}  
        //public int idUserInfo {get; set;}        
        //Navigation Properties
        public UserInfo? UserInfo { get; set; }
    }
}