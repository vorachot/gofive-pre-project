using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
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

        //Add new User(POST)->api/users
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
        //Get User By Id(GET)->api/users/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var user = await userRepository.GetUserById(id);
            if (user == null)
            {
                return BadRequest(); // 400 if user not found
            }
            return Ok(user);
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var user = await userRepository.DeleteUser(id);
            if (user == null)
            {
                return BadRequest(); // 400 if user not found
            }
            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, CreateUserRequestDto editedUser)
        {
            var user = await userRepository.UpdateUser(id, editedUser);
            if (user == null)
            {
                return BadRequest();
            }
            return Ok(user);

        }

    }
}
