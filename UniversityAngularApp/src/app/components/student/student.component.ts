import { Component, OnInit } from '@angular/core';
import { StudentService } from 'src/app/services/student.service';
import { StudentItem } from 'src/app/models/student-items';
//import{}
/*
public int Id { get; set; }
        public string? Email { get; set;}
        public int YearOfStudy {get; set;}
        public string? Specialization {get; set;}  

*/
@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  styleUrls: ['./student.component.scss']
})
export class StudentComponent implements OnInit {
  studentItems : StudentItem[] = [];
  newStudentItem : StudentItem = {};
  updateStudentItem : StudentItem = {};
  idStudent = 0;
  constructor(private studentService : StudentService) { }

  ngOnInit(): void {
    this.studentService.getStudents()
    .subscribe((studentItems: StudentItem[]) => {
      this.studentItems=studentItems;
    });
  }
  addStudentItem() {
    this.studentService.addStudentItem(this.newStudentItem)
    .subscribe((studentItems) =>
    this.studentItems.push(studentItems));
    this.newStudentItem = {};
  }
  
  deleteStudentItem(id: number) { 
    this.studentService.deleteStudentItem(id).subscribe((id) => { this.ngOnInit(); });
  }
  updateStudentItems() {
    if (this.updateStudentItem.id) {
      this.studentService.updateStudentItem(this.updateStudentItem).subscribe((studentItem) => 
       this.studentItems.push(studentItem));
      }
      window.location.reload();
    this.updateStudentItem = {};
    }
}
