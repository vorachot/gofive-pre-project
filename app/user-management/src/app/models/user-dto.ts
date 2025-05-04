export interface UserDto {
  id: string;
  firstName: string;
  lastName: string;
  email: string;
  phone: string;
  role: RoleDto;
  username: string;
  permissions: UserPermissionDto[];
}
export interface RoleDto {
  roleId: string;
  roleName: string;
}
export interface UserPermissionDto {
  permissionId: string;
  permissionName: string;
}
