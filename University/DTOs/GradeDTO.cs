namespace University.DTOs
{
    public class GradeDTO
    {
        public int Id { get; set; }
        public int IdCourse { get; set; }
        public int IdStudent { get; set; }
        public int IdTeacher { get; set; }
        public int IdSession { get; set; }
        public int GradeValue {get; set;}
        public DateTime ExamDate {get; set;}

        //Navigation Properties
        public CourseDTO? Course {get; set;}
        public StudentDTO? Student {get; set;}
        public TeacherDTO? Teacher { get; set; }
        public SessionDTO? Session { get; set;}
    }
}

