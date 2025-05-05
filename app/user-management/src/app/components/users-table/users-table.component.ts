import { Component } from '@angular/core';
import { RoleDto, UserDto, UserPermissionDto } from 'src/app/models/user-dto';
import { UserService } from 'src/app/services/user.service';
import { RoleService } from 'src/app/services/role.service';
import { PermissionService } from 'src/app/services/permission.service';
declare var bootstrap: any;
@Component({
  selector: 'app-users-table',
  templateUrl: './users-table.component.html',
  styleUrls: ['./users-table.component.css'],
})
export class UsersTableComponent {
  users: UserDto[] | undefined;
  roles: RoleDto[] | undefined;
  permissions: UserPermissionDto[] | undefined;
  selectedUserToEdit?: UserDto;
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

  onEditUser(userId: string) {
    this.userService.getUserById(userId).subscribe({
      next: (user: UserDto) => {
        this.selectedUserToEdit = user;
        console.log('Selected user for edit:', this.selectedUserToEdit);
        const modalElement = document.getElementById('addUserModal');
        const modal = new bootstrap.Modal(modalElement!);
        modal.show();
      },
      error: (err) => {
        console.error('Failed to fetch user:', err);
      },
    });
  }
  onDeleteUser(userId: string) {
    if (confirm('Are you sure you want to delete this user?')) {
      this.userService.deleteUser(userId).subscribe({
        next: (response) => {
          console.log(response);
          this.fetchUsers(); // Refresh table
        },
        error: (err) => {
          console.error('Error deleting user:', err);
          alert('Failed to delete user');
        },
      });
    }
  }
}
