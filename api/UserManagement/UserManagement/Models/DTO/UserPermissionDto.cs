namespace UserManagement.Models.DTO
{
    public class UserPermissionDto
    {
        public Guid PermissionId { get; set; }
        public required string PermissionName { get; set; }
    }
}
