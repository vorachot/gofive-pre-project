using UserManagement.Models.Domain;

namespace UserManagement.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<User> CreateUserAsync(User user);
    }
}
