using UserManagement.Models.DTO;

namespace UserManagement.Repositories.Interface
{
    public interface IPermissionRepository
    {
        Task<List<UserPermissionDto>> GetPermissions();
    }
}
