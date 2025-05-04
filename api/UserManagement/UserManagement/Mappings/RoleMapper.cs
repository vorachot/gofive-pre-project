using UserManagement.Models.Domain;
using UserManagement.Models.DTO;

namespace UserManagement.Mappings
{
    public static class RoleMapper
    {
        public static RoleDto ToDto(this Role role)
        {

            return new RoleDto
            {
                RoleId = role.Id,
                RoleName = role.Name,
            };
        }
    }
}
