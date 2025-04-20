import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CreateUserRequest } from '../models/create-user-request';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class UserService {

  constructor(private http: HttpClient) {}

  createUser(user: CreateUserRequest): Observable<void> {
    return this.http.post<void>('https://localhost:7128/api/users', user);
  }
}
