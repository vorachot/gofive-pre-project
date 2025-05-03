using UserManagement.Models.DTO;

namespace UserManagement.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<UserDto?> CreateUser(CreateUserDto param);
        Task<UserDto?> GetUserById(Guid id);
        Task<List<User>> GetUsers();
        Task<UserDto?> UpdateUser(Guid id, CreateUserDto user);
        Task<Boolean> DeleteUser(Guid id);
    }
}
