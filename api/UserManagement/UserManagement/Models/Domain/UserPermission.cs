using UserManagement.Models.Domain;

public class UserPermission
{
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public Guid PermissionId { get; set; }
    public Permission Permission { get; set; } = null!;

    public bool IsReadable { get; set; }
    public bool IsWritable { get; set; }
    public bool IsDeletable { get; set; }
}
