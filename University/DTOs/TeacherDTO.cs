namespace University.DTOs
{
    public class TeacherDTO
    {
        public int Id { get; set; }
        public string? Email { get; set;}
        public string? DidacticRole {get; set;}
        
        //Navigation Properties
        public UserInfoDTO? UserInfo { get; set; }
    }
}