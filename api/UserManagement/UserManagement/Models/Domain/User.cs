using UserManagement.Models.Domain;

public class User
{
    public Guid Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public string? Phone { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }
    public DateOnly CreatedDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);

    public Guid RoleId { get; set; }
    public Role Role { get; set; } = null!;

    public ICollection<UserPermission> UserPermissions { get; set; } = new List<UserPermission>();
}