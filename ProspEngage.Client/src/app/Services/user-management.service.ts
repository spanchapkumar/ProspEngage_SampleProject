import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../Shared/Model/Usermodel';
import { environment } from '../Environments/environment.dev';

@Injectable({
  providedIn: 'root'
})
export class UserManagementService {
  private baseUrl = environment.apiBaseUrl;
  constructor(private http: HttpClient) {}  

getUsers(): Observable<User[]> {
  const apiUrl = `${this.baseUrl}/UsersManagement/getUsers`;
  debugger;
  return this.http.get<User[]>(apiUrl);
}

  createUser(data: any): Observable<any> {
    debugger;
    return this.http.post(`${this.baseUrl}/UsersManagement`, data);
  }
}