namespace University.Models
{
    public class Grade
    {
        public int Id { get; set; }
        public int IdCourse { get; set; }
        public int IdStudent { get; set; }
        public int IdTeacher { get; set; }
        public int IdSession { get; set; }
        public int GradeValue {get; set;}
        public DateTime ExamDate {get; set;}

        //Navigation Properties
        public Course? Course {get; set;}
        public Student? Student {get; set;}
        public Teacher? Teacher { get; set; }
        public Session? Session { get; set;}
    }
}

