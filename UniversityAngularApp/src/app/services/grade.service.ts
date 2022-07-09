import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { API_URL } from '../constants';
import { GradeItem } from '../models/grade-items';

@Injectable({
  providedIn: 'root'
})
export class GradeService {
  constructor(private httpClient: HttpClient) { }

  getGrades() {
      return this.httpClient.get<GradeItem[]>(API_URL + 'grade');
  }
  getGradesByStudent(idStudent?: number){
    return this.httpClient.get<GradeItem[]>(API_URL + 'grade?idStudent=' + idStudent); 
  }

  addGradeItem(gradeItem: GradeItem){
    return this.httpClient.post<GradeItem>(API_URL + 'grade', gradeItem)
  }


deleteGradeItem(id: number) {
  return this.httpClient.delete<number>(
  API_URL + 'grade/' + id);
  }
updateGradeItem(gradeItem: GradeItem) {
  return this.httpClient.put<GradeItem>(API_URL + 'grade/' + gradeItem.id, gradeItem);
}
}
