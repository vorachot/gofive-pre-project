﻿namespace UserManagement.Models.DTO
{
    public class CreateUserDto
    {
        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public required string Email { get; set; }

        public string? Phone { get; set; }

        public required string Username { get; set; }

        public required string Password { get; set; }

        public Guid RoleId {  get; set; }

        public required List<CreateUserPermissionDto> Permissions { get; set; }
    }
}
