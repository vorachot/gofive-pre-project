using UserManagement.Models.DTO;

namespace UserManagement.Mappings
{
    public static class UserMapper
    {
        public static UserDto ToDto(this User user)
        {

            return new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Phone = user.Phone,
                Username = user.Username,
                Role = new RoleDto
                {
                    RoleId = user.Role.Id,
                    RoleName = user.Role.Name
                },
                Permissions = user.UserPermissions.Select(up => new UserPermissionDto
                {
                    PermissionId = up.PermissionId,
                    PermissionName = up.Permission.Name,
                }).ToList()
            };
        }
    }
}
