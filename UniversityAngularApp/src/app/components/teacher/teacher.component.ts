import { Component, OnInit } from '@angular/core';
import { TeacherService } from 'src/app/services/teacher.service';
import { TeacherItem } from 'src/app/models/teacher-items';

/*
public int Id { get; set; }
        public string? Email { get; set;}
        public string? DidacticRole {get; set;}
*/

@Component({
  selector: 'app-teacher',
  templateUrl: './teacher.component.html',
  styleUrls: ['./teacher.component.scss']
})
export class TeacherComponent implements OnInit {
  teacherItems : TeacherItem[] = [];
  newTeacherItem : TeacherItem = {};
  updateTeacherItem : TeacherItem = {};
  idTeacher = 0;
  constructor(private teacherService : TeacherService) { }

  ngOnInit(): void {
    this.teacherService.getTeachers()
    .subscribe((teacherItems: TeacherItem[]) => {
      this.teacherItems=teacherItems;
    });
  }
  addTeacherItem() {
    this.teacherService.addTeacherItem(this.newTeacherItem)
    .subscribe((teacherItems) =>
    this.teacherItems.push(teacherItems));
    this.newTeacherItem = {};
  }
  
  deleteTeacherItem(id: number) { 
    this.teacherService.deleteTeacherItem(id).subscribe((id) => { this.ngOnInit(); });
  }
  updateTeacherItems() {
    if (this.updateTeacherItem.id) {
      this.teacherService.updateTeacherItem(this.updateTeacherItem).subscribe((teacherItem) => 
       this.teacherItems.push(teacherItem));
      }
      window.location.reload();
    this.updateTeacherItem = {};
    }
}
