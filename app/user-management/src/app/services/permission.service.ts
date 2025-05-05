import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserPermissionDto } from '../models/user-dto';

@Injectable({
  providedIn: 'root',
})
export class PermissionService {
  constructor(private http: HttpClient) {}

  getPermissions(): Observable<UserPermissionDto[]> {
    return this.http.get<UserPermissionDto[]>(
      'https://localhost:7128/api/permissions'
    );
  }
}
