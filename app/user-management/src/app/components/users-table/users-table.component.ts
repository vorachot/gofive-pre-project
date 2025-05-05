import { Component } from '@angular/core';
import { RoleDto, UserDto, UserPermissionDto } from 'src/app/models/user-dto';
import { UserService } from 'src/app/services/user.service';
import { RoleService } from 'src/app/services/role.service';
import { PermissionService } from 'src/app/services/permission.service';

@Component({
  selector: 'app-users-table',
  templateUrl: './users-table.component.html',
  styleUrls: ['./users-table.component.css'],
})
export class UsersTableComponent {
  users: UserDto[] | undefined;
  roles: RoleDto[] | undefined;
  permissions: UserPermissionDto[] | undefined;
  constructor(
    private userService: UserService,
    private roleService: RoleService,
    private permissionService: PermissionService
  ) {}

  ngOnInit() {
    this.fetchUsers();
    this.fetchRoles();
    this.fetchPermissions();
  }

  fetchUsers() {
    this.userService.getUsers().subscribe({
      next: (data) => {
        this.users = data;
        console.log('Users data:', this.users);
      },
      error: (err) => {
        console.error('Error fetching users:', err);
      },
    });
  }
  fetchRoles() {
    this.roleService.getRoles().subscribe({
      next: (data) => {
        this.roles = data;
        console.log('Roles data:', this.roles);
      },
      error: (err) => {
        console.error('Error fetching roles:', err);
      },
    });
  }
  fetchPermissions() {
    this.permissionService.getPermissions().subscribe({
      next: (data) => {
        this.permissions = data;
        console.log('Permissions data:', this.permissions);
      },
      error: (err) => {
        console.error('Error fetching permissions:', err);
      },
    });
  }
}
