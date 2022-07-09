namespace University.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string? Email { get; set;}
        public string? DidacticRole {get; set;}
        //public int idUserInfo {get; set;} 
        //Navigation Properties
        public UserInfo? UserInfo { get; set; }
    }
}