namespace University.DTOs
{
    public class CourseDTO
    {
        public int  Id { get; set; }
        public int IdTeacher { get; set; }
        public string? CourseName { get; set; }
    
        //Navigation Properties
        public TeacherDTO? Teacher { get; set; }
        
    }
}