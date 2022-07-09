namespace University.Models
{
    public class Course
    {
        public int  Id { get; set; }
        public int IdTeacher { get; set; }
        public string? CourseName { get; set; }
    
        //Navigation Properties
        public Teacher? Teacher { get; set; }
        
    }
}