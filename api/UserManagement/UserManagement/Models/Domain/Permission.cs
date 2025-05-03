namespace UserManagement.Models.Domain
{
    public class Permission
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }

        public ICollection<UserPermission> UserPermissions { get; set; } = new List<UserPermission>();
    }


}
