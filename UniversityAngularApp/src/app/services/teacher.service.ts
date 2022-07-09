import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {API_URL} from '../constants';
import { TeacherItem } from '../models/teacher-items';  

@Injectable({
  providedIn: 'root'
})
export class TeacherService {

  constructor(private httpClient: HttpClient) { }

  getTeachers() {
      return this.httpClient.get<TeacherItem[]>(API_URL + 'teacher');
  }
  addTeacherItem(teacherItem : TeacherItem) {
      return this.httpClient.post<TeacherItem>(API_URL + 'teacher', teacherItem);
  }
  deleteTeacherItem(id: number) {
    return this.httpClient.delete<number>(
    API_URL + 'teacher/' + id);
    }
  updateTeacherItem(teacherItem: TeacherItem) {
    return this.httpClient.put<TeacherItem>(API_URL + 'teacher/' + teacherItem.id, teacherItem);
  }
}
