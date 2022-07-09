namespace University.DTOs
{
    public class StudentDTO
    {
        //[Key]
        public int Id { get; set; }
        public string? Email { get; set;}
        public int YearOfStudy {get; set;}
        public string? Specialization {get; set;}  
        
        //Navigation Properties
        public UserInfoDTO? UserInfo { get; set; }
    }
}