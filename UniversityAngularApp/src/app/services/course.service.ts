import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {API_URL} from '../constants';
import { CourseItem } from '../models/course-items';

@Injectable({
  providedIn: 'root'
})
export class CourseService {

  constructor(private httpClient: HttpClient) { }

  getCourses() {
      return this.httpClient.get<CourseItem[]>(API_URL + 'course');
  }
  addCourseItem(courseItem: CourseItem) {
      return this.httpClient.post<CourseItem>(API_URL + 'course', courseItem);
  }
  deleteCourseItem(id: number) {
    return this.httpClient.delete<number>(
    API_URL + 'course/' + id);
    }
  updateCourseItem(courseItem: CourseItem) {
    return this.httpClient.put<CourseItem>(API_URL + 'course/' + courseItem.id, courseItem);
  }
}
