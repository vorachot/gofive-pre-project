import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CreateUserDto } from '../models/create-user-dto';
import { Observable } from 'rxjs';
import { UserDto } from '../models/user-dto';
import { DeleteUserResponse } from '../models/delete-user-response';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  constructor(private http: HttpClient) {}

  createUser(user: CreateUserDto): Observable<void> {
    return this.http.post<void>('https://localhost:7128/api/users', user);
  }

  getUserById(id: string): Observable<UserDto> {
    return this.http.get<UserDto>(`https://localhost:7128/api/users/${id}`);
  }

  getUsers(): Observable<UserDto[]> {
    return this.http.get<UserDto[]>(
      'https://localhost:7128/api/users/DataTable'
    );
  }

  deleteUser(id: string): Observable<DeleteUserResponse> {
    return this.http.delete<DeleteUserResponse>(
      `https://localhost:7128/api/users/${id}`
    );
  }

  updateUser(id: string, user: CreateUserDto): Observable<UserDto> {
    return this.http.put<UserDto>(
      `https://localhost:7128/api/users/${id}`,
      user
    );
  }
}
