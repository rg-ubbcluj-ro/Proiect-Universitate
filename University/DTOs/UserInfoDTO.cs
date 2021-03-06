namespace University.DTOs
{
    public class UserInfoDTO
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string Email { get; set;} 
        public string Password {get; set;}
        public DateTime CreatedAt {get; set;}
        public string? Role {get; set;}
    }
}