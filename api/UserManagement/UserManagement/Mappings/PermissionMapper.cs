using UserManagement.Models.Domain;
using UserManagement.Models.DTO;

namespace UserManagement.Mappings
{
    public static class PermissionMapper
    {
        public static UserPermissionDto ToDto(this Permission permission)
        {

            return new UserPermissionDto
            {
                PermissionId = permission.Id,
                PermissionName = permission.Name,
            };
        }
    }
}
