using Microsoft.EntityFrameworkCore;
using UserManagement.Data;
using UserManagement.Mappings;
using UserManagement.Models.DTO;
using UserManagement.Repositories.Interface;

namespace UserManagement.Repositories.Implementation
{
    public class RoleRepository: IRoleRepository
    {
        private readonly ApplicationDbContext dbContext;

        public RoleRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<RoleDto>> GetRoles()
        {
            return await dbContext.Roles
                                  .Select(role => role.ToDto())
                                  .ToListAsync();
        }
    }
}
