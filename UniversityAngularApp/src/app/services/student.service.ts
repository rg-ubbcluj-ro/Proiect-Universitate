import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {API_URL} from '../constants';
import { StudentItem } from '../models/student-items';  

@Injectable({
  providedIn: 'root'
})
export class StudentService {

  constructor(private httpClient: HttpClient) { }

  getStudents() {
      return this.httpClient.get<StudentItem[]>(API_URL + 'student');
  }
  addStudentItem(studentItem : StudentItem) {
      return this.httpClient.post<StudentItem>(API_URL + 'student', studentItem);
  }
  deleteStudentItem(id: number) {
    return this.httpClient.delete<number>(
    API_URL + 'student/' + id);
    }
  updateStudentItem(studentItem : StudentItem) {
    return this.httpClient.put<StudentItem>(API_URL + 'student/' + studentItem.id, studentItem);
  }
}
