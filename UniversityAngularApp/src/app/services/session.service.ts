import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {API_URL} from '../constants';
import { SessionItem } from '../models/session-items';

@Injectable({
  providedIn: 'root'
})
export class SessionService {
constructor(private httpClient: HttpClient) { }

  getSessions() {
      return this.httpClient.get<SessionItem[]>(API_URL + 'session');
  }
  addSessionItem(sessionItem : SessionItem) {
      return this.httpClient.post<SessionItem>(API_URL + 'session', sessionItem);
  }
  deleteSessionItem(id: number) {
    return this.httpClient.delete<number>(
    API_URL + 'session/' + id);
    }
  updateSessionItem(sessionItem : SessionItem) {
    return this.httpClient.put<SessionItem>(API_URL + 'session/' + sessionItem.id, sessionItem);
  }
}
