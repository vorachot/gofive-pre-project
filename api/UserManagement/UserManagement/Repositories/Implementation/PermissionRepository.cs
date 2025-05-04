using Microsoft.EntityFrameworkCore;
using UserManagement.Data;
using UserManagement.Mappings;
using UserManagement.Models.DTO;
using UserManagement.Repositories.Interface;

namespace UserManagement.Repositories.Implementation
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly ApplicationDbContext dbContext;

        public PermissionRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<UserPermissionDto>> GetPermissions()
        {
            return await dbContext.Permissions
                                  .Select(permission => permission.ToDto())
                                  .ToListAsync();
        }
    }
}
