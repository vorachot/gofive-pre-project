using Microsoft.EntityFrameworkCore;
using UserManagement.Data;
using UserManagement.Mappings;
using UserManagement.Models.DTO;
using UserManagement.Repositories.Interface;

namespace UserManagement.Repositories.Implementation
{
    public class UserRepository: IUserRepository
    {
        private readonly ApplicationDbContext dbContext;

        public UserRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<User?> GetUserWithDetailsAsync(Guid id)
        {
            return await dbContext.Users
                .Include(u => u.Role)
                .Include(u => u.UserPermissions)
                    .ThenInclude(up => up.Permission)
                .FirstOrDefaultAsync(u => u.Id == id);
        }
        public async Task<UserDto?> CreateUser(CreateUserDto param)
        {
            var newUser = new User
            {
                FirstName = param.FirstName,
                LastName = param.LastName,
                Email = param.Email,
                Phone = param.Phone,
                Username = param.Username,
                Password = param.Password,
                RoleId = param.RoleId,
                UserPermissions = param.Permissions.Select(p => new UserPermission
                {
                    UserId = Guid.Empty,
                    PermissionId = p.PermissionId,
                    IsReadable = p.IsReadable,
                    IsWritable = p.IsWritable,
                    IsDeletable = p.IsDeletable
                }).ToList()
            };
            await dbContext.Users.AddAsync(newUser);
            await dbContext.SaveChangesAsync();
            var dbUser = await GetUserWithDetailsAsync(newUser.Id);

            return dbUser.ToDto();
        }
        public async Task<UserDto?> GetUserById(Guid id)
        {
            var dbUser = await GetUserWithDetailsAsync(id);
            if (dbUser == null) return null;
            return dbUser.ToDto();

        }
        public async Task<List<UserDto>> GetUsers()
        {
            var users = await dbContext.Users.Include(u => u.Role).Include(u => u.UserPermissions).ThenInclude(up => up.Permission).ToListAsync();
            return users.Select(user => user.ToDto()).ToList();
        }
        public async Task<UserDto?> UpdateUser(Guid id, CreateUserDto param)
        {
            var editedUser = await dbContext.Users.Include(u => u.UserPermissions).FirstOrDefaultAsync(x => id.Equals(x.Id));
            if (editedUser == null) return null;

            editedUser.FirstName = param.FirstName;
            editedUser.LastName = param.LastName;
            editedUser.Email = param.Email;
            editedUser.Phone = param.Phone;
            editedUser.RoleId = param.RoleId;
            editedUser.Username = param.Username;
            editedUser.Password = param.Password;
            editedUser.CreatedDate = DateOnly.FromDateTime(DateTime.Now);

            dbContext.UserPermissions.RemoveRange(editedUser.UserPermissions);

            editedUser.UserPermissions = param.Permissions.Select(p => new UserPermission
            {
                UserId = editedUser.Id,
                PermissionId = p.PermissionId,
                IsReadable = p.IsReadable,
                IsWritable = p.IsWritable,
                IsDeletable = p.IsDeletable
            }).ToList();

            await dbContext.SaveChangesAsync();
            var dbUser = await GetUserWithDetailsAsync(id);
            return dbUser.ToDto();
        }
        public async Task<Boolean> DeleteUser(Guid id)
        {
            var user = await dbContext.Users.FirstOrDefaultAsync(x => id.Equals(x.Id));
            if (user == null) return false;
            dbContext.Users.Remove(user);
            await dbContext.SaveChangesAsync();
            return true;
        }
        
    }
}
