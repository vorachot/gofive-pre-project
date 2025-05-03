namespace UserManagement.Models.DTO
{
    public class UserDto
    {
        public Guid Id { get; set; }

        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public required string Email { get; set; }

        public string? Phone { get; set; }

        public required RoleDto Role { get; set; }

        public required string Username { get; set; }

        public required List<UserPermissionDto> Permissions { get; set; }
    }
}
