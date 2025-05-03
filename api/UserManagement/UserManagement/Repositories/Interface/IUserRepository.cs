using UserManagement.Models.Domain;
using UserManagement.Models.DTO;

namespace UserManagement.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<User> CreateUserAsync(User user);
        Task<User> GetUserById(Guid id);
        Task<User> DeleteUser(Guid id);
        Task<User> UpdateUser(Guid id, CreateUserRequestDto user);
    }
}
