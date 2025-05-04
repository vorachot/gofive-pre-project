using UserManagement.Models.DTO;

namespace UserManagement.Repositories.Interface
{
    public interface IRoleRepository
    {
        Task<List<RoleDto>> GetRoles();
    }
}
