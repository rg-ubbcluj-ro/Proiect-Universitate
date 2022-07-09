import { CourseItem } from "./course-items";
import { SessionItem } from "./session-items";
import { StudentItem } from "./student-items";
import { TeacherItem } from "./teacher-items";

/*public int Id { get; set; }
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
        public Session? Session { get; set;}*/
        export interface GradeItem{
            id: number;
            idCourse?: number;
            idStudent?: number;
            idTeacher?: number;
            idSession?: number;
            gradeValue?: number;
            examDate?: Date;
            course?: CourseItem;
            student?: StudentItem;
            teacher?: TeacherItem;
            session?: SessionItem;
            
        }