export interface CreateUserDto {
  firstName: string;
  lastName: string;
  email: string;
  phone: string;
  username: string;
  password: string;
  roleId: string;
  permissions: CreateUserPermissionDto[];
}
export interface CreateUserPermissionDto {
  permissionId: string;
  isReadable: boolean;
  isWritable: boolean;
  isDeletable: boolean;
}
