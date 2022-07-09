import { Component, OnInit } from '@angular/core';
import { GradeItem } from 'src/app/models/grade-items';
import { GradeService } from 'src/app/services/grade.service';

@Component({
  selector: 'app-grade',
  templateUrl: './grade.component.html',
  styleUrls: ['./grade.component.scss']
})
export class GradeComponent implements OnInit {
  gradesItems: GradeItem[] = [];
  gradeItems: GradeItem[] = [];
  newGradeItem: GradeItem = {
    id: 0
  };
  //newCourseItem : CourseItem = {};
  updateGradeItem: GradeItem = {
    id: 0
  };



  constructor(private gradeService: GradeService) { }

  /*ngOnInit(): void {
    this.gradeService.getGradesByStudent(this.idStudent)
    .subscribe((gradeItems: GradeItem[]) => {
      this.gradesItems=gradeItems;
    });
  }*/

  ngOnInit(): void {
    // this.gradeService.getGrades()
    //   .subscribe((gradeItems: GradeItem[]) => {
    //     this.gradesItems = gradeItems;
    //   });
    this.gradeService.getGradesByStudent()
      .subscribe((gradeItems: GradeItem[]) => {
        this.gradesItems = gradeItems;
      });
  }
  addGradeItem() {
    this.gradeService.addGradeItem(this.newGradeItem)
      .subscribe((courseItems) =>
        this.gradesItems.push(courseItems));
    this.newGradeItem = { id: 0 };
  }

  deleteGradeItem(id: number) {
    this.gradeService.deleteGradeItem(id).subscribe((id) => { this.ngOnInit(); });
  }
  updateGradeItems() {
    if (this.updateGradeItem.id) {
      this.gradeService.updateGradeItem(this.updateGradeItem).subscribe((gradeItem) =>
        this.gradeItems.push(gradeItem));
    }
    window.location.reload();
    this.updateGradeItem = { id: 0 };
  }

}
