import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule} from './app-routing.module';
import { AppComponent} from './app.component';
import {UserComponent} from './components/user/user.component';
import { FormsModule } from '@angular/forms';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {StudentComponent} from './components/student/student.component';
import{TeacherComponent} from './components/teacher/teacher.component';
import{CourseComponent} from './components/course/course.component';
import { SessionComponent } from './components/session/session.component';
import { GradeComponent } from './components/grade/grade.component';
import { LoginComponent } from './components/login/login.component';
import {MatSnackBarModule} from '@angular/material/snack-bar';
import {ReactiveFormsModule} from '@angular/forms';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {MatButtonModule} from '@angular/material/button';
import {MatButtonToggleModule} from '@angular/material/button-toggle';
import {MatCardModule} from '@angular/material/card';
import {MatTableModule} from '@angular/material/table';
import {MatIconModule} from '@angular/material/icon';
import { TokenInterceptor } from './interceptor/token-interceptor.service';
import { NavBarComponent } from './components/nav-bar/nav-bar.component';
@NgModule({
  declarations: [
    AppComponent,
    UserComponent,
    StudentComponent,
    TeacherComponent,
    CourseComponent,
    SessionComponent,
    GradeComponent,
    LoginComponent,
    NavBarComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule,
    BrowserAnimationsModule,
    MatSnackBarModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatButtonToggleModule,
    MatCardModule,
    MatTableModule,
    MatIconModule,


  ],
  providers: [
    {
    provide: HTTP_INTERCEPTORS, useClass: TokenInterceptor, multi: true,
   },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
