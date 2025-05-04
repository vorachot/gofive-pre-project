using Microsoft.AspNetCore.Mvc;
using UserManagement.Repositories.Interface;

namespace UserManagement.Controllers
{

    [Route("api/permissions")]
    [ApiController]
    public class PermissionsController: ControllerBase
    {
        private readonly IPermissionRepository permissionRepository;

        public PermissionsController(IPermissionRepository permissionRepository)
        {
            this.permissionRepository = permissionRepository;
        }

        /// <summary>
        /// Get all Permissions.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetPermissions()
        {
            return Ok(await permissionRepository.GetPermissions());
        }
    }
}
