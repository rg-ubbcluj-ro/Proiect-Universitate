/**
 public int  Id { get; set; }
        public int IdTeacher { get; set; }
        public string? CourseName { get; set; }
 */
export interface CourseItem {
    id: number;
    idTeacher: number;
    courseName?: string;
}
