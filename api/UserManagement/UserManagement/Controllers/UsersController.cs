using Microsoft.AspNetCore.Mvc;
using UserManagement.Models.DTO;
using UserManagement.Models.DTO.Common;
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

        //Add new User(POST)-> api/users
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDto param)
        {
            var userDto = await userRepository.CreateUser(param);

            return Ok(userDto);
        }

        //Get Users(POST)-> api/users/DataTable
        [HttpPost("DataTable")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await userRepository.GetUsers();

            return Ok(users);
        }


        //Get User By Id(GET)-> api/users/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var user = await userRepository.GetUserById(id);
            if (user == null) return BadRequest(); // 400 if user not found
            return Ok(user);
        }

        //Delete User(DELETE)-> api/users/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var status = await userRepository.DeleteUser(id);
            if (status == false)
                return BadRequest(new DeleteUserResponse
                {
                    Result = false,
                    Message = "User not found"
                });
            return Ok(new DeleteUserResponse
            {
                Result = true,
                Message = "User has been deleted"
            });
        }

        //Edit User(PUT)-> api/users/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, CreateUserDto editedUser)
        {
            var userDto = await userRepository.UpdateUser(id, editedUser);
            if (userDto == null)
            {
                return BadRequest();
            }
            return Ok(userDto);

        }

    }
}
