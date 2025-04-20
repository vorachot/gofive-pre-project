using UserManagement.Data;
using UserManagement.Models.Domain;
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
        public async Task<User> CreateUserAsync(User user)
        {
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();

            return user;
        }
    }
}
