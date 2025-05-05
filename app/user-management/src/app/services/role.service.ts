import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { RoleDto } from '../models/user-dto';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class RoleService {
  constructor(private http: HttpClient) {}

  getRoles(): Observable<RoleDto[]> {
    return this.http.get<RoleDto[]>('https://localhost:7128/api/roles');
  }
}
