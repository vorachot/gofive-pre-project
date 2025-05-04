using Microsoft.AspNetCore.Mvc;
using UserManagement.Repositories.Interface;

namespace UserManagement.Controllers
{
    [Route("api/roles")]
    [ApiController]
    public class RolesController: ControllerBase
    {
        private readonly IRoleRepository roleRepository;

        public RolesController(IRoleRepository roleRepository)
        {
            this.roleRepository = roleRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetRoles() 
        {
            return Ok(await roleRepository.GetRoles());
        }
    }
}
