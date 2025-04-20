using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Models.Domain;
using UserManagement.Models.DTO;
using UserManagement.Repositories.Interface;

namespace UserManagement.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository userRepository;

        public UsersController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserRequestDto request)
        {
            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Phone = request.Phone,
                Username = request.Username,
                Password = request.Password,
            };

            await userRepository.CreateUserAsync(user);

            return Ok();
        }

        /*[HttpGet]
        public Task<IActionResult> GetUserById(string id)
        {
            User user = Sql
            return user
        }*/
        
    }
}
