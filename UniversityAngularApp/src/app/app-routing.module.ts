import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserComponent } from './components/user/user.component';
import { StudentComponent } from './components/student/student.component';
import { TeacherComponent } from './components/teacher/teacher.component';
import { CourseComponent } from './components/course/course.component';
import { SessionComponent } from './components/session/session.component';
import { GradeComponent } from './components/grade/grade.component';
import { LoginComponent } from './components/login/login.component';
const routes: Routes = [
  {
    path: 'User',
    component: UserComponent,
  },
  {
    path: 'Student',
    component: StudentComponent,
  },
  {
    path: 'Teacher',
    component: TeacherComponent,
  },
  {
    path: 'Course',
    component: CourseComponent,
  },
  {
    path: 'Session',
    component: SessionComponent,
  },
  {
    path: 'Grade',
    component: GradeComponent,
  },
  {
    path: 'Auth/login',
    component: LoginComponent,
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
