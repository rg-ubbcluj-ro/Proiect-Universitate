import { Component, OnInit } from '@angular/core';
import { TeacherService } from 'src/app/services/teacher.service';
import { TeacherItem } from 'src/app/models/teacher-items';
import { CourseItem } from 'src/app/models/course-items';
import { CourseService } from 'src/app/services/course.service';

@Component({
  selector: 'app-course',
  templateUrl: './course.component.html',
  styleUrls: ['./course.component.scss']
})
export class CourseComponent implements OnInit {
  courseItems : CourseItem[] = [];
  newCourseItem : CourseItem = {
    idTeacher: 0,
    id: 0
  };
  //newCourseItem : CourseItem = {};
  updateCourseItem : CourseItem = {
    idTeacher: 0,
    id: 0
  };
  idCourse = 0;
  constructor(private courseService : CourseService) { }

  ngOnInit(): void {
    this.courseService.getCourses()
    .subscribe((courseItems: CourseItem[]) => {
      this.courseItems=courseItems;
    });
  }
  addCourseItem() {
    this.courseService.addCourseItem(this.newCourseItem)
    .subscribe((courseItems) =>
    this.courseItems.push(courseItems));
    this.newCourseItem = { idTeacher: 0, id: 0 };
  }
  
  deleteCourseItem(id: number) { 
    this.courseService.deleteCourseItem(id).subscribe((id) => { this.ngOnInit(); });
  }
  updateCourseItems() {
    if (this.updateCourseItem.id) {
      this.courseService.updateCourseItem(this.updateCourseItem).subscribe((courseItem) => 
       this.courseItems.push(courseItem));
      }
      window.location.reload();
    this.updateCourseItem = { idTeacher: 0, id: 0 };
    }
}
