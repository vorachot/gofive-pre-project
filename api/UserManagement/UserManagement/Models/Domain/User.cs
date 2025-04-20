using System.Security;

namespace UserManagement.Models.Domain
{
    public class User
    {
        public Guid Id { get; set; }

        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public required string Email { get; set; }

        public string? Phone { get; set; }

        //public required string RoleId { get; set; }

        public required string Username { get; set; }

        public required string Password { get; set; }

        /*public required string PermissionId { get; set; }

        public required bool IsReadable { get; set; }

        public required bool IsWritable { get; set; }

        public required bool IsDeletable { get; set; }*/

        public DateOnly CreatedDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);

    }
}
