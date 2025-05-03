namespace UserManagement.Models.DTO
{
    public class CreateUserPermissionDto
    {
        public required Guid PermissionId { get; set; }

        public required bool IsReadable { get; set; }
        public required bool IsWritable { get; set; }
        public required bool IsDeletable { get; set; }
    }
}
