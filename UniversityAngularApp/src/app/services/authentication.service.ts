import {HttpClient} from '@angular/common/http';
import {Injectable} from '@angular/core';
import {RouteConfigLoadEnd, Router} from '@angular/router';
import {Observable} from 'rxjs';
import {API_URL} from '../constants';
import {UserItem} from '../models/user-items';

@Injectable({
  providedIn: 'root',
})
export class AuthenticationService {
  constructor(private httpClient: HttpClient, private router: Router) { }

  isAuthenticated(): boolean {
    return localStorage.getItem('token') !== null;
  }

  register(email: string, password: string, firstName: string, lastName: string, role: string): 
    Observable<UserItem> {
    const userInfo: UserItem = {
      email: email,
      password: password,
      firstName: firstName,
      lastName: lastName,
      createdAt: new Date(),
      role: role,
    };
      // isConfirmed: isConfirmed,
    return this.httpClient.post<UserItem>(
      `${API_URL}token/register`, userInfo);
  }

  login(userItem: UserItem): Observable<any> {
    console.log(userItem);
    return this.httpClient.post<any>(
      `${API_URL}token/login`, userItem);
  }

  logout(): void {
    localStorage.removeItem('token');
  }

  redirectToLogin(): void {
    this.router.navigate(['Auth/login']);
  }
}
