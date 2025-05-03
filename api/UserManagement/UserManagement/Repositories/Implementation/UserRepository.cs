using Microsoft.EntityFrameworkCore;
using UserManagement.Data;
using UserManagement.Models.Domain;
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
        public async Task<User> CreateUserAsync(User user)
        {
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<User> GetUserById(Guid id)
        {
            return await dbContext.Users.FirstOrDefaultAsync(x=> id.Equals(x.Id));
            
        }

        public async Task<User> DeleteUser(Guid id)
        {
            var user = await dbContext.Users.FirstOrDefaultAsync(x => id.Equals(x.Id));
            if(user == null)
            {
                return null;
            }
            dbContext.Users.Remove(user);
            await dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateUser(Guid id, CreateUserRequestDto user)
        {
            var dbUser = await dbContext.Users.FirstOrDefaultAsync(x => id.Equals(x.Id));
            if(dbUser == null)
            {
                return null;
            }
            dbUser.FirstName = user.FirstName; 
            dbUser.LastName = user.LastName;
            dbUser.Email = user.Email;
            dbUser.Phone = user.Phone;
            dbUser.Username = user.Username;
            dbUser.Password = user.Password;
            dbUser.CreatedDate = DateOnly.FromDateTime(DateTime.Now);

            await dbContext.SaveChangesAsync();
            return dbUser;
        }
    }
}
